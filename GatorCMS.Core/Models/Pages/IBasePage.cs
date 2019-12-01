using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GatorCMS.Core.Models.Pages
{
    public interface IBasePage
    {
        [BsonId]
        public CustomID _id { get; set; }

        public string PageName { get; set; }
        public bool ShowInNavigation { get; set; }
    }
}