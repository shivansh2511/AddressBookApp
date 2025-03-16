using AddressBookAPI.DTOs;
using AddressBookAPI.Models;
using AddressBookAPI.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _service;

        public AddressBookController(IAddressBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AddressBookEntry>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AddressBookEntry> GetById(int id)
        {
            var entry = _service.GetById(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public ActionResult<AddressBookEntry> Create([FromBody] AddressBookDto dto)
        {
            var newEntry = _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = newEntry.Id }, newEntry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AddressBookDto dto)
        {
            var updatedEntry = _service.Update(id, dto);
            if (updatedEntry == null) return NotFound();
            return Ok(updatedEntry);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
