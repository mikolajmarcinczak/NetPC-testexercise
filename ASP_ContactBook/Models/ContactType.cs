namespace ASP_ContactBook.Models
{
    public class ContactType
    {
        public string TypeName { get; set; }
        public ContactTypeRole TypeRole { get; set; }
        public IList<UserInfo> Users { get; set; }
    }
}
