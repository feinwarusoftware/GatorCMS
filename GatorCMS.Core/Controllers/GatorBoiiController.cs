using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.GatorService;
using Microsoft.AspNetCore.Mvc;

namespace GatorCMS.Core.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class GatorBoiiController : ControllerBase {
        private readonly IGatorService _gatorService;

        public GatorBoiiController (GatorService gatorService) {
            _gatorService = gatorService;
        }

        [HttpGet]

        public ActionResult<List<GatorBoii>> Get () {
            return _gatorService.Get ();
        }

        [HttpGet ("{id:length(24)}", Name = "GetGator")]
        public ActionResult<GatorBoii> Get (string id) {
            var book = _gatorService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<GatorBoii> Create (GatorBoii book) {
            _gatorService.Create (book);

            return CreatedAtRoute ("GetGator", new { id = book.Id.ToString () }, book);
        }

        [HttpPut ("{id:length(24)}")]
        public IActionResult Update (string id, GatorBoii gatorIn) {
            var book = _gatorService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            _gatorService.Update (id, gatorIn);

            return NoContent ();
        }

        [HttpDelete ("{id:length(24)}")]
        public IActionResult Delete (string id) {
            var book = _gatorService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            _gatorService.Remove (book, book.Id);

            return NoContent ();
        }
    }
}