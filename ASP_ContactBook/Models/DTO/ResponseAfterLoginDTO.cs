namespace ASP_ContactBook.Models
{
    public class ResponseAfterLoginDTO : ResponseDTO
    {
        public bool IsLoggedIn { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
    }
}
