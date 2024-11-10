using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection; //MongoCollection'dan Brand sınıfı için bir field türetiyoruz.
        private readonly IMapper _mapper; //Automapper'ı kullanmak için mapper field'ı oluşturuyoruz.

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);  //Brand tablosuna da bu şekilde erişim sağlanır.
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto); //Brand entitysi ile createBrandDto dan gelen parametreler eşleştirilmiş olur.
            await _brandCollection.InsertOneAsync(value);  //Mongodb'de ekleme işlemi InsertOneAsync ile yapılıyor. Bu şekilde Asekron olarak ekleme işlemi yapılır.
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync(); //Tüm değerleri getirmek için kullanılır.
            return _mapper.Map<List<ResultBrandDto>>(values); //Bu şekilde maplenmiş veri geri döndürülür.
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values); //Mongodb de update işlemi FindOneAndReplace ile yapılır.

        }
    }
}
