using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId] //Mongoda ID olduğunu belirtmek için BsonId attribute'u kullanılıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Bu şekilde de benzersiz olduğunu belirtmiş oluyoruz.
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
