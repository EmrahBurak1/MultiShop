﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class About
    {
        [BsonId] //Mongoda ID olduğunu belirtmek için BsonId attribute'u kullanılıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Bu şekilde de benzersiz olduğunu belirtmiş oluyoruz.
        public string AboutId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
