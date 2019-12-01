using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GatorCMS.Core.Models.Pages
{
    public interface IBasePage
    {
        [BsonId]
        public Guid _id { get; set; }
        public string _t { get; set; }
        public string PageName { get; set; }
        public bool ShowInNavigation { get; set; }
    }
}