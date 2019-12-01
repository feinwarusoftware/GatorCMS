using System;
using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GatorCMS.Core.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class GatorPagesBaseController<T> : ControllerBase where T : IBasePage {

        private readonly IGatorPagesService _gatorPagesService;
        public GatorPagesBaseController (IGatorPagesService gatorPagesService) {
            _gatorPagesService = gatorPagesService;
        }

        [Route ("[action]")]
        [HttpGet]
        public List<T> GetAllPages () {
            var gatorPages = _gatorPagesService.GetPages<T> ();
            return gatorPages;
        }

        [Route ("[action]/{id}")]
        [HttpGet]
        public T GetPage (string id) {
            var page = _gatorPagesService.GetPage<T> (Guid.Parse (id));

            return page;
        }

        [Route ("[action]")]
        [HttpPost]
        public T CreatePage (T page) {
            var createdPage = _gatorPagesService.CreatePage (page);
            return createdPage;
        }
    }
}