using Microsoft.AspNetCore.Identity;

namespace ASP_ContactBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        public UserInfo UserInfo { get; set; }
        public UserDetail UserDetail { get; set; }
        public IList<ApplicationUser>? ContactList { get; set; }
    }
}
