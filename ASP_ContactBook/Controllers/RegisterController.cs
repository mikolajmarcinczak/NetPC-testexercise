using ASP_ContactBook.Models;
using ASP_ContactBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ContactBook.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterController> _logger;
        private readonly IUsersService _usersService;

        public RegisterController(UserManager<ApplicationUser> userManager, 
                                  SignInManager<ApplicationUser> signInManager, 
                                  RoleManager<IdentityRole> roleManager, 
                                  ILogger<RegisterController> logger, 
                                  IUsersService usersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseAfterLoginDTO> Login([FromBody] UserDTO userDTO)
        {
            var login = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, lockoutOnFailure: true);
            if (login.Succeeded)
            {
                _logger.LogInformation("User logged in.");
            }
            else
            {
                _logger.LogInformation("Login failed.");
                return new ResponseAfterLoginDTO { Code = 400, Message = "Login failed.", Status = "Failed" };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseAfterLoginDTO> Register([FromBody]UserDTO userDTO)
        {
            var newUser = new ApplicationUser {  }
        }
    }
}
