using ASP_ContactBook.Data;
using ASP_ContactBook.Models;
using AutoMapper;

namespace ASP_ContactBook.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<UsersService> logger;
        private readonly IMapper mapper;

        public UsersService(ApplicationDbContext context, ILogger<UsersService> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public ResponseDTO AddUser(UserDTO userDTO)
        {
            logger.LogInformation($"Executing AddUser method.");

            try
            {
                context.ApplicationUser.Add(mapper.Map<ApplicationUser>(userDTO));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Error while adding user to the database." };
            }

            return new ResponseDTO { Code = 200, Message = $"User {userDTO.Email} added to the database.", Status = "Success" };
        }

        public ResponseDTO DeleteUser(string mail)
        {
            logger.LogInformation($"Executing DeleteUser method");

            var user = context.ApplicationUser.Where(u => u.Email == mail).SingleOrDefault();
            if (user == null)
            {
                return new ResponseDTO { Code = 400, Message = $"There is no user with {mail} address.", Status = "Error" };
            }

            try
            {
                context.ApplicationUser.Remove(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Error while removing user from the database." };
            }

            return new ResponseDTO { Code = 200, Message = $"User {mail} deleted from the database.", Status = "Success" };
        }

        public ResponseDTO EditUser(UserDTO userDTO)
        {
            logger.LogInformation($"Executing EditUser method");

            if (context.Users.Where(u => u.Id == userDTO.Id).Count() == 0)
            {
                return new ResponseDTO { Code = 400, Message = $"There is no user with ID: {userDTO.Id} in the database.", Status = "Error" };
            }

            try
            {
                context.ApplicationUser.Update(mapper.Map<ApplicationUser>(userDTO));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = "Error while updating user.", Status = "Error" };
            }

            return new ResponseDTO { Code = 200, Message = $"User with ID: {userDTO.Id} updated.", Status = "Success" };
        }

        public UsersDTO GetUsers()
        {
            logger.LogInformation($"Executing GetUsers method");
            
            UsersDTO usersDTO = new UsersDTO();
            usersDTO.Users = new List<UserDTO>();

            var users = context.ApplicationUser.ToList();
            foreach (var user in users)
            {
                usersDTO.Users.Add(mapper.Map<UserDTO>(user));
            }

            return usersDTO;
        }

        //Get user info for session after logging in
        public ResponseDTO GetUserId(string mail)
        {
            logger.LogInformation($"Executing GetUserId method");

            var user = context.ApplicationUser.Where(x => x.Email == mail).SingleOrDefault();
            if (user == null)
            {
                return new ResponseDTO { Code = 400, Message = "There is no user with {mail} address" };
            }

            return new ResponseAfterLoginDTO { Code = 200, Message = "User logged in.", Status = "Success", UserID = user.Id, Email = user.Email };
        }
    }
}
