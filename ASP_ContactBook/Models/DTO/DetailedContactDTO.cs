namespace ASP_ContactBook.Models
{
    public class DetailedContactDTO : ContactDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
