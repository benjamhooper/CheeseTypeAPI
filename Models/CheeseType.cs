using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheeseTypeAPI.Models
{
    public class CheeseType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}