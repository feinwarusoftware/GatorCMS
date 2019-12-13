
namespace GatorCMS.Core.Models.Pages
{
    public class ArticlePage : BasePage
    {
        public string Title { get; set; }
        public string Introduction {get;set;}
        public string Body { get; set; }

        public string ImageName { get; set; }
        public byte[] Image { get; set; }
    }
}