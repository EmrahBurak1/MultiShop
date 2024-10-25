using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection; //MongoCollection'dan category sınıfı için bir field türetiyoruz.
        private readonly IMapper _mapper; //Automapper'ı kullanmak için mapper field'ı oluşturuyoruz.

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);  //Category tablosuna da bu şekilde erişim sağlanır.
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(createFeatureSliderDto); //Mapleme işlemi gerçekleştiriliyor.
            await _featureSliderCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync(); //Tüm category'leri getirir.
            return _mapper.Map<List<ResultFeatureSliderDto>>(values); 
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync(); //Id'ye göre category getirir.
            return _mapper.Map<GetByIdFeatureSliderDto>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, values);
        }
    }
}
