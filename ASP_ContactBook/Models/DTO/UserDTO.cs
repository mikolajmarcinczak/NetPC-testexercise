namespace ASP_ContactBook.Models
{
    public class UserDTO
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string ContactType { get; set; }
        public virtual string ContactTypeRole { get; set; }


    }
}
