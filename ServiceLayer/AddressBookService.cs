using AddressBookAPI.Data;
using AddressBookAPI.DTOs;
using AddressBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.ServiceLayer
{
    public class AddressBookService : IAddressBookService
    {
        private readonly AppDbContext _context;

        public AddressBookService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AddressBookEntry> GetAll()
        {
            return _context.AddressBook.ToList();
        }

        public AddressBookEntry GetById(int id)
        {
            return _context.AddressBook.Find(id);
        }

        public AddressBookEntry Add(AddressBookDto dto)
        {
            var newEntry = new AddressBookEntry
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.AddressBook.Add(newEntry);
            _context.SaveChanges();
            return newEntry;
        }

        public AddressBookEntry Update(int id, AddressBookDto dto)
        {
            var entry = _context.AddressBook.Find(id);
            if (entry == null) return null;

            entry.Name = dto.Name;
            entry.Email = dto.Email;
            entry.Phone = dto.Phone;

            _context.SaveChanges();
            return entry;
        }

        public bool Delete(int id)
        {
            var entry = _context.AddressBook.Find(id);
            if (entry == null) return false;

            _context.AddressBook.Remove(entry);
            _context.SaveChanges();
            return true;
        }
    }
}
