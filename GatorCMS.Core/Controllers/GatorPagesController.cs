using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GatorCMS.Core.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class GatorPagesController : ControllerBase {

        private readonly IGatorPagesService _gatorPagesService;
        public GatorPagesController (IGatorPagesService gatorPagesService) {
            _gatorPagesService = gatorPagesService;
        }

        [HttpGet]
        public List<BasePage> Get () {
            var gatorPages = _gatorPagesService.GetAllPages ();

            return gatorPages;
        }

        [HttpGet ("{id:length(24)}", Name = "GetBasePage")]
        public BasePage Get (string id) {
            var page = _gatorPagesService.GetPage(ObjectId.Parse(id));

            if (page == null)
            {
                return new BasePage{
                    PageName = "Not Found"
                };
            }

            return page;
        }

        [HttpPost]
        public BasePage Create (BasePage page) {
            var createdPage = _gatorPagesService.CreateBasePage (page);

            return createdPage;
        }
    }
}