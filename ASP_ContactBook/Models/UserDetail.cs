namespace ASP_ContactBook.Models
{
    public class UserDetail
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
