using AddressBookAPI.DTOs;
using AddressBookAPI.Models;

namespace AddressBookAPI.ServiceLayer
{
    public interface IAddressBookService
    {
        IEnumerable<AddressBookEntry> GetAll();
        AddressBookEntry GetById(int id);
        AddressBookEntry Add(AddressBookDto dto);
        AddressBookEntry Update(int id, AddressBookDto dto);
        bool Delete(int id);
    }
}
