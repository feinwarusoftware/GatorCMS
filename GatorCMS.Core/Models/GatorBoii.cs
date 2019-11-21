using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GatorCMS.Core.Models {
    public class GatorBoii {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { set; get; }

        public string name { set; get; }

        public uint fucksGiven { set; get; }
    }
}