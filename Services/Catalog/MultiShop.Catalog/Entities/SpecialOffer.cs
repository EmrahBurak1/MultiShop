using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId] //Mongoda ID olduğunu belirtmek için BsonId attribute'u kullanılıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Bu şekilde de benzersiz olduğunu belirtmiş oluyoruz.
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
