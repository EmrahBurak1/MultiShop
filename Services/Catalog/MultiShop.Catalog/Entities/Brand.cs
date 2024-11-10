using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Brand
    {
        [BsonId] //Mongoda ID olduğunu belirtmek için BsonId attribute'u kullanılıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Bu şekilde de benzersiz olduğunu belirtmiş oluyoruz.
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
