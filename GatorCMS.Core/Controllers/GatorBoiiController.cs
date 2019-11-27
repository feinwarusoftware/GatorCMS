using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.LemonService;
using Microsoft.AspNetCore.Mvc;

namespace GatorCMS.Core.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class GatorBoiiController : ControllerBase {
        private readonly ILemonService _lemonService;

        public GatorBoiiController (LemonService lemonService) {
            _lemonService = lemonService;
        }

        [HttpGet]

        public ActionResult<List<Lemon>> Get () {
            return _lemonService.Get();
        }

        [HttpGet ("{id:length(24)}", Name = "GetGator")]
        public ActionResult<Lemon> Get (string id) {
            var book = _lemonService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Lemon> Create (Lemon book) {
            _lemonService.Create (book);

            return CreatedAtRoute ("GetGator", new { id = book.Id.ToString () }, book);
        }

        [HttpPut ("{id:length(24)}")]
        public IActionResult Update (string id, Lemon gatorIn) {
            var book = _lemonService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            _lemonService.Update (id, gatorIn);

            return NoContent ();
        }

        [HttpDelete ("{id:length(24)}")]
        public IActionResult Delete (string id) {
            var book = _lemonService.Get (id);

            if (book == null) {
                return NotFound ();
            }

            _lemonService.Remove (book.Id);

            return NoContent ();
        }
    }
}