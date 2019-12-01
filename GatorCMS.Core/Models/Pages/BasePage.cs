using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GatorCMS.Core.Models.Pages
{
    public abstract class BasePage: IBasePage
    {

        public BasePage()
        {
            _id = new CustomID(this.GetType().FullName);
        }

        [BsonId]
        public CustomID _id { get; set; }
        public string PageName { get; set; }
        public bool ShowInNavigation { get; set; }
    }
}