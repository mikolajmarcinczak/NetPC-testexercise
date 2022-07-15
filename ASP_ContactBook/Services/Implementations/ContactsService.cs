using ASP_ContactBook.Data;
using ASP_ContactBook.Models;
using AutoMapper;

namespace ASP_ContactBook.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public ContactsService(ApplicationDbContext context, ILogger logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        //List of contacts if not logged in
        public ContactsDTO GetAllContacts()
        {
            logger.LogInformation($"Executing GetAllContacts method.");

            var users = context.ApplicationUser.ToList();

            var contacts = new ContactsDTO();
            contacts.Contacts = new List<ContactDTO>();

            foreach (var user in users)
            {
                contacts.Contacts.Add(mapper.Map<ContactDTO>(user));
            }

            return contacts;
        }

        //Get user details if not logged in
        public DetailedContactDTO GetDetailedContact(string mail)
        {
            logger.LogInformation($"Executing GetDetailedContact method.");

            var detailedUser = context.ApplicationUser.Where(du => du.Email == mail).SingleOrDefault();
            DetailedContactDTO detailedContact = mapper.Map<DetailedContactDTO>(detailedUser);

            return detailedContact;
        }
    }
}
