namespace ASP_ContactBook.Models
{
    public class ContactTypeRole
    {
        public string Role { get; set; }
        public string TypeName { get; set; }
        public ContactType ContactType { get; set; }
    }
}
