using ASP_ContactBook.Models;

namespace ASP_ContactBook.Services
{
    public interface IContactsService
    {
        ContactsDTO GetAllContacts();
        DetailedContactDTO GetDetailedContact(string mail);
    }
}
