using ASP_ContactBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ContactBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService contactsService;
        private readonly ILogger<ContactsController> logger;

        public ContactsController(IContactsService contactsService, ILogger<ContactsController> logger)
        {
            this.contactsService = contactsService;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/contact/getcontacts")]
        public IActionResult GetAllContacts()
        {
            logger.LogInformation("Executing GetAllContacts controller.");
            return Ok(contactsService.GetAllContacts());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/contact/getcontact/{mail}")]
        public IActionResult GetDetailedContact(string mail)
        {
            logger.LogInformation("Executing GetDetailedContact controller.");
            return Ok(contactsService.GetDetailedContact(mail));
        }
    }
}
