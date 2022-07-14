using ASP_ContactBook.Models;

namespace ASP_ContactBook.Services
{
    public interface IContactsService
    {
        ContactsDTO GetAllContacts();
        DetailedContactDTO GetDetailedContact(string mail);
        ResponseDTO AddContact(DetailedContactDTO detailedContactDTO); //Success after login
        ResponseDTO EditContact(DetailedContactDTO detailedContactDTO); //Success after login
        ResponseDTO DeleteContact(string mail); //Success after login

    }
}
