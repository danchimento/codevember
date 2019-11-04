using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace danchimento.Models
{
    public class DopeShit
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}