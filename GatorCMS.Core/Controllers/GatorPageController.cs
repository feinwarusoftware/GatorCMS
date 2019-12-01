using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;


namespace GatorCMS.Core.Controllers
{
    public class GatorPageController : GatorPagesBaseController<GatorPage>
    {
        public GatorPageController(IGatorPagesService gatorPagesService) : base (gatorPagesService)
        {
        }

    }
}