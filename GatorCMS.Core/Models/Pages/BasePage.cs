using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GatorCMS.Core.Models.Pages
{
    public class BasePage
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { set; get; }

        public string PageName { get; set; }
    }
}