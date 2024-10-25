using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId] //Mongoda ID olduğunu belirtmek için BsonId attribute'u kullanılıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Bu şekilde de benzersiz olduğunu belirtmiş oluyoruz.
        public string FeatureSliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
