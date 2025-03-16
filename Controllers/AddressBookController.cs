// Controllers/AddressBookController.cs
using Microsoft.AspNetCore.Mvc;
using AddressBookAPI.Data;
using AddressBookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Inject the AppDbContext via constructor injection.
        public AddressBookController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/addressbook - Fetch all contacts.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressBookEntry>>> GetAll()
        {
            var contacts = await _context.AddressBookEntries.ToListAsync();
            return Ok(contacts);
        }

        // GET /api/addressbook/{id} - Get contact by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBookEntry>> GetById(int id)
        {
            var contact = await _context.AddressBookEntries.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST /api/addressbook - Add a new contact.
        [HttpPost]
        public async Task<ActionResult<AddressBookEntry>> Create(AddressBookEntry entry)
        {
            _context.AddressBookEntries.Add(entry);
            await _context.SaveChangesAsync();
            // Returns a 201 Created response with the new resource location.
            return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
        }

        // PUT /api/addressbook/{id} - Update a contact.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressBookEntry entry)
        {
            if (id != entry.Id)
            {
                return BadRequest("ID mismatch");
            }

            _context.Entry(entry).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.AddressBookEntries.FindAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE /api/addressbook/{id} - Delete a contact.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.AddressBookEntries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            _context.AddressBookEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
