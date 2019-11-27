using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GatorCMS.Core.Models.Pages
{
    public class BasePage
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PageName { get; set; }
        public bool ShowInNavigation { get; set; }
    }
}