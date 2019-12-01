using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;

namespace GatorCMS.Core.Controllers
{
    public class ArticleController : GatorPagesBaseController<ArticlePage>
    {
        public ArticleController(IGatorPagesService gatorPagesService) : base (gatorPagesService)
        {
     
        }
    }
}