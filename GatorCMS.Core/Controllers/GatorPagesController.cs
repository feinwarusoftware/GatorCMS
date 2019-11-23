using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;
using Microsoft.AspNetCore.Mvc;

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
            var gatorPages = _gatorPagesService.GetAllPages();
            
            return gatorPages;
        }
    }
}