using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection; //MongoCollection'dan ProductImage sınıfı için bir field türetiyoruz.
        private readonly IMapper _mapper; //Automapper'ı kullanmak için mapper field'ı oluşturuyoruz.

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImagesCollectionName);  //ProductImage tablosuna da bu şekilde erişim sağlanır.
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto); //ProductImage entitysi ile createProductImageDto dan gelen parametreler eşleştirilmiş olur.
            await _ProductImageCollection.InsertOneAsync(value);  //Mongodb'de ekleme işlemi InsertOneAsync ile yapılıyor. Bu şekilde Asekron olarak ekleme işlemi yapılır.
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync(); //Tüm değerleri getirmek için kullanılır.
            return _mapper.Map<List<ResultProductImageDto>>(values); //Bu şekilde maplenmiş veri geri döndürülür.
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values); //Mongodb de update işlemi FindOneAndReplace ile yapılır.

        }
    }
}
