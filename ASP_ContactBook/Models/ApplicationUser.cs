using Microsoft.AspNetCore.Identity;

namespace ASP_ContactBook.Models
{
    public class ApplicationUser : IdentityUser //This model is overly complicated (misunderstood the instruction), I realised how much simpler it could be only after setting up Model Configurations, and learning about auto-mapper. With limited time I just wanted to move on insted of refactoring.
    {
        public UserInfo UserInfo { get; set; }
        public UserDetail UserDetail { get; set; }
        public IList<ApplicationUser>? ContactList { get; set; }
    }
}
