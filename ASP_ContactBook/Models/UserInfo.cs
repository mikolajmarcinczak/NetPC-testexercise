namespace ASP_ContactBook.Models
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TypeName { get; set; }
        public ContactType ContactType { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
