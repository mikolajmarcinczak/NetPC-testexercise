namespace ASP_ContactBook.Models
{
    public class ResponseAfterLoginDTO : ResponseDTO
    {
        public string UserID { get; set; }
        public string Email { get; set; }
    }
}
