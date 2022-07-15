using ASP_ContactBook.Models;

namespace ASP_ContactBook.Services
{
    public interface IUsersService
    {
        UsersDTO GetUsers();
        ResponseDTO AddUser(UserDTO userDTO);
        ResponseDTO EditUser(UserDTO userDTO);
        ResponseDTO DeleteUser(string mail);
    }
}