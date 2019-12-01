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
        public GatorPagesBaseController(IGatorPagesService gatorPagesService) {
            _gatorPagesService = gatorPagesService;
        }

        [HttpGet]
        public List<T> Get() {
            var gatorPages = _gatorPagesService.GetPages<T>();
            return gatorPages;
        }

        [HttpGet ("{id:length(24)}")]
        public T Get(string id) {
            var page = _gatorPagesService.GetPage<T>(Guid.Parse(id));

            return page;
        }

        [HttpPost]
        public T Create(T page) {
            var createdPage = _gatorPagesService.CreatePage(page);
            return createdPage;
        }
    }
}