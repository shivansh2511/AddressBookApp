using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Models;

namespace AddressBookAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AddressBookEntry> AddressBook { get; set; }
    }
}
