
namespace AddressBookAPI.Models
{
    public class AddressBookEntry
    {
        // Primary key for the entry.
        public int Id { get; set; }
        
        // Name of the contact.
        public string Name { get; set; }
        
        // Email address of the contact.
        public string Email { get; set; }
        
        // Phone number of the contact.
        public string Phone { get; set; }
        
        // Address details.
        public string Address { get; set; }
    }
}
