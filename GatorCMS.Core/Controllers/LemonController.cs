using System.Collections.Generic;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.LemonService;
using Microsoft.AspNetCore.Mvc;

namespace GatorCMS.Core.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class LemonController : ControllerBase
    {
        private readonly ILemonService _lemonService;

        public LemonController (ILemonService lemonService)
        {
            _lemonService = lemonService;
        }

        [HttpGet]
        public ActionResult<List<Lemon>> Get()
        {
            return _lemonService.Get();
        }

        [HttpGet ("{id:length(24)}", Name = "GetLemon")]
        public ActionResult<Lemon> Get(string id)
        {
            var lemon = _lemonService.Get(id);

            if (lemon == null)
            {
                return NotFound();
            }

            return lemon;
        }

        [HttpPost]
        public ActionResult<Lemon> Create(Lemon lemon)
        {
            _lemonService.Create(lemon);

            return CreatedAtRoute("GetLemon", new { id = lemon.Id.ToString() }, lemon);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Lemon lemon)
        {
            var book = _lemonService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _lemonService.Update(id, lemon);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _lemonService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _lemonService.Remove(id);

            return NoContent();
        }
    }
}