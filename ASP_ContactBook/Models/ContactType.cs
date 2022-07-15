namespace ASP_ContactBook.Models
{
    //This would be a dictionary type stored in the db. Select-option in frontend would take data from ContactType and ContactTypeRole.
    public class ContactType
    {
        public string TypeName { get; set; }
        public ContactTypeRole TypeRole { get; set; }
        public IList<UserInfo> Users { get; set; }
    }
}
