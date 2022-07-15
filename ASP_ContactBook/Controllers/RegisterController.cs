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
        public async Task<ResponseDTO> Login([FromBody] UserDTO userDTO)
        {
            var login = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, lockoutOnFailure: true);
            if (login.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return _usersService.GetUserId(userDTO.Email); //Return info about logged user
            }
            else
            {
                _logger.LogInformation("Login failed.");
                return new ResponseAfterLoginDTO { Code = 400, Message = "Login failed.", Status = "Failed" };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseDTO> Register([FromBody]UserDTO userDTO)
        {
            ContactType ct = new ContactType { TypeName = userDTO.ContactType, TypeRole = new ContactTypeRole { Role = userDTO.ContactTypeRole} };
            UserInfo ui = new UserInfo { Name = userDTO.Name, Surname = userDTO.Surname, ContactType = ct };
            UserDetail ud = new UserDetail { Email = userDTO.Email, PhoneNumber = userDTO.PhoneNumber, BirthDate = userDTO.BirthDate };

            var newUser = new ApplicationUser { UserDetail = ud, UserInfo = ui };
            var register = await _userManager.CreateAsync(newUser, userDTO.Password);

            if (register.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User")) //Create 'User' role if not exists
                {
                    var role = new IdentityRole("User");
                    var registerRole = await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(newUser, "User");
                _logger.LogInformation($"New user account with mail {userDTO.Email} created.");
                
                await _signInManager.SignInAsync(newUser, false);

                return _usersService.GetUserId(userDTO.Email); //Return info about logged user
            }

            _logger.LogInformation("User registration failed.");
            return new ResponseAfterLoginDTO { Code = 400, Message = "User registration failed.", Status = "Failed" };
        }
    }
}
