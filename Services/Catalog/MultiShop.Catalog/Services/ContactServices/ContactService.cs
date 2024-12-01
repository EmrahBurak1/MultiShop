using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection; //MongoCollection'dan Contact sınıfı için bir field türetiyoruz.
        private readonly IMapper _mapper; //Automapper'ı kullanmak için mapper field'ı oluşturuyoruz.

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);  //Contact tablosuna da bu şekilde erişim sağlanır.
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto); //Contact entitysi ile createContactDto dan gelen parametreler eşleştirilmiş olur.
            await _contactCollection.InsertOneAsync(value);  //Mongodb'de ekleme işlemi InsertOneAsync ile yapılıyor. Bu şekilde Asekron olarak ekleme işlemi yapılır.
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync(); //Tüm değerleri getirmek için kullanılır.
            return _mapper.Map<List<ResultContactDto>>(values); //Bu şekilde maplenmiş veri geri döndürülür.
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values); //Mongodb de update işlemi FindOneAndReplace ile yapılır.

        }
    }
}
