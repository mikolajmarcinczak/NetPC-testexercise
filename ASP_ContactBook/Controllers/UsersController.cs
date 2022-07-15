using ASP_ContactBook.Models;
using ASP_ContactBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ContactBook.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("/api/user/add")]
        public IActionResult AddUser([FromBody] UserDTO userDTO)
        {
            logger.LogInformation("executing AddUser controller.");
            return Ok(usersService.AddUser(userDTO));
        }

        [HttpPut]
        [Route("/api/user/edit")]
        public IActionResult EditUser([FromBody] UserDTO userDTO)
        {
            logger.LogInformation("executing EditUser controller.");
            return Ok(usersService.EditUser(userDTO));
        }

        [HttpDelete]
        [Route("/api/user/delete/{mail}")]
        public IActionResult DeleteUser(string mail)
        {
            logger.LogInformation("executing DeleteUser controller.");
            return Ok(usersService.DeleteUser(mail));
        }

        [HttpGet]
        [Route("/api/user/getusers")]
        public IActionResult GetUsers()
        {
            logger.LogInformation("executing GetUsers controller.");
            return Ok(usersService.GetUsers());
        }
    }
}
