using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GatorCMS.Core.Models.Pages
{
    public class BasePage
    {
       

        public string PageName { get; set; }

        public bool ShowInNavigation { get; set; }
    }
}