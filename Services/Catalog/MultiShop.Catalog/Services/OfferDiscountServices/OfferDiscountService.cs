using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection; //MongoCollection'dan OfferDiscount sınıfı için bir field türetiyoruz.
        private readonly IMapper _mapper; //Automapper'ı kullanmak için mapper field'ı oluşturuyoruz.

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);  //OfferDiscount tablosuna da bu şekilde erişim sağlanır.
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto); //OfferDiscount entitysi ile createOfferDiscountDto dan gelen parametreler eşleştirilmiş olur.
            await _offerDiscountCollection.InsertOneAsync(value);  //Mongodb'de ekleme işlemi InsertOneAsync ile yapılıyor. Bu şekilde Asekron olarak ekleme işlemi yapılır.
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync(); //Tüm değerleri getirmek için kullanılır.
            return _mapper.Map<List<ResultOfferDiscountDto>>(values); //Bu şekilde maplenmiş veri geri döndürülür.
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountCollection.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, values); //Mongodb de update işlemi FindOneAndReplace ile yapılır.

        }
    }
}
