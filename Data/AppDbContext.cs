using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Models;

namespace AddressBookAPI.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor accepts DbContextOptions and passes them to the base class.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Represents the AddressBookEntries table in the database.
        public DbSet<AddressBookEntry> AddressBookEntries { get; set; }
    }
}