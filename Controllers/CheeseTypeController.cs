using System.Collections.Generic;
using CheeseTypeAPI.Models;
using CheeseTypeAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CheeseTypeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseTypeController : ControllerBase
    {
        private readonly CheeseTypeService _cheeseTypeService;

        public CheeseTypeController(CheeseTypeService cheeseTypeService)
        {
            _cheeseTypeService = cheeseTypeService;
        }

        [HttpGet]
        public ActionResult<List<CheeseType>> Get() =>
            _cheeseTypeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCheeseType")]
        public ActionResult<CheeseType> Get(string id)
        {
            var cheese = _cheeseTypeService.Get(id);

            if (cheese == null)
            {
                return NotFound();
            }

            return cheese;
        }

        [HttpPost]
        public ActionResult<CheeseType> Create(CheeseType cheeseType)
        {
            _cheeseTypeService.Create(cheeseType);

            return CreatedAtRoute("GetCheeseType", new { id = cheeseType.Id.ToString() }, cheeseType);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CheeseType CheeseIn)
        {
            var Cheese = _cheeseTypeService.Get(id);

            if (Cheese == null)
            {
                return NotFound();
            }

            _cheeseTypeService.Update(id, CheeseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Cheese = _cheeseTypeService.Get(id);

            if (Cheese == null)
            {
                return NotFound();
            }

            _cheeseTypeService.Remove(Cheese.Id);

            return NoContent();
        }
    }
}