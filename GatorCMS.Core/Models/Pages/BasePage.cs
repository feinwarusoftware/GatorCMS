using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GatorCMS.Core.Models.Pages
{
    public abstract class BasePage: IBasePage
    {

        public BasePage()
        {
            _id = Guid.NewGuid();
            _t = this.GetType().FullName;
        }

        [BsonId]
        public Guid _id { get; set; }
        public string _t { get; set; }
        public string PageName { get; set; }
        public bool ShowInNavigation { get; set; }
    }
}