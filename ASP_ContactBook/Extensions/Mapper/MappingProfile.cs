using ASP_ContactBook.Models;
using AutoMapper;

namespace ASP_ContactBook.Extensions.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                    .ForMember(u => u.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(u => u.Name, map => map.MapFrom(m => m.UserInfo.Name))
                    .ForMember(u => u.Surname, map => map.MapFrom(m => m.UserInfo.Surname))
                    .ForMember(u => u.Password, map => map.MapFrom(m => m.PasswordHash))
                    .ForMember(u => u.Email, map => map.MapFrom(m => m.UserDetail.Email))
                    .ForMember(u => u.PhoneNumber, map => map.MapFrom(m => m.UserDetail.PhoneNumber))
                    .ForMember(u => u.BirthDate, map => map.MapFrom(m => m.UserDetail.BirthDate))
                    .ForMember(u => u.ContactType, map => map.MapFrom(m => m.UserInfo.ContactType.TypeName))
                    .ForMember(u => u.ContactTypeRole, map => map.MapFrom(m => m.UserInfo.ContactType.TypeRole.Role));
            CreateMap<UserDTO, ApplicationUser>()
                    .ForMember(u => u.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(u => u.UserInfo.Name, map => map.MapFrom(m => m.Name))
                    .ForMember(u => u.UserInfo.Surname, map => map.MapFrom(m => m.Surname))
                    .ForMember(u => u.PasswordHash, map => map.MapFrom(m => m.Password))
                    .ForMember(u => u.UserDetail.Email, map => map.MapFrom(m => m.Email))
                    .ForMember(u => u.UserDetail.PhoneNumber, map => map.MapFrom(m => m.PhoneNumber))
                    .ForMember(u => u.UserDetail.BirthDate, map => map.MapFrom(m => m.BirthDate))
                    .ForMember(u => u.UserInfo.ContactType.TypeName, map => map.MapFrom(m => m.ContactType))
                    .ForMember(u => u.UserInfo.ContactType.TypeRole.Role, map => map.MapFrom(m => m.ContactTypeRole));

            CreateMap<ApplicationUser, ContactDTO>()
                    .ForMember(c => c.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(c => c.Name, map => map.MapFrom(m => m.UserInfo.Name))
                    .ForMember(c => c.Surname, map => map.MapFrom(m => m.UserInfo.Surname))
                    .ForMember(c => c.ContactType, map => map.MapFrom(m => m.UserInfo.ContactType.TypeName))
                    .ForMember(c => c.ContactTypeRole, map => map.MapFrom(m => m.UserInfo.ContactType.TypeRole.Role));
            CreateMap<ContactDTO, ApplicationUser>()
                    .ForMember(c => c.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(c => c.UserInfo.Name, map => map.MapFrom(m => m.Name))
                    .ForMember(c => c.UserInfo.Surname, map => map.MapFrom(m => m.Surname))
                    .ForMember(c => c.UserInfo.ContactType.TypeName, map => map.MapFrom(m => m.ContactType))
                    .ForMember(c => c.UserInfo.ContactType.TypeRole.Role, map => map.MapFrom(m => m.ContactTypeRole));

            CreateMap<ApplicationUser, DetailedContactDTO>()
                    .ForMember(c => c.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(c => c.Name, map => map.MapFrom(m => m.UserInfo.Name))
                    .ForMember(c => c.Surname, map => map.MapFrom(m => m.UserInfo.Surname))
                    .ForMember(c => c.ContactType, map => map.MapFrom(m => m.UserInfo.ContactType.TypeName))
                    .ForMember(c => c.ContactTypeRole, map => map.MapFrom(m => m.UserInfo.ContactType.TypeRole.Role))
                    .ForMember(c => c.Email, map => map.MapFrom(m => m.UserDetail.Email))
                    .ForMember(c => c.PhoneNumber, map => map.MapFrom(m => m.UserDetail.PhoneNumber))
                    .ForMember(c => c.BirthDate, map => map.MapFrom(m => m.UserDetail.BirthDate));
            CreateMap<DetailedContactDTO, ApplicationUser>()
                    .ForMember(c => c.Id, map => map.MapFrom(m => m.Id))
                    .ForMember(c => c.UserInfo.Name, map => map.MapFrom(m => m.Name))
                    .ForMember(c => c.UserInfo.Surname, map => map.MapFrom(m => m.Surname))
                    .ForMember(c => c.UserInfo.ContactType.TypeName, map => map.MapFrom(m => m.ContactType))
                    .ForMember(c => c.UserInfo.ContactType.TypeRole.Role, map => map.MapFrom(m => m.ContactTypeRole))
                    .ForMember(c => c.UserDetail.Email, map => map.MapFrom(m => m.Email))
                    .ForMember(c => c.UserDetail.PhoneNumber, map => map.MapFrom(m => m.PhoneNumber))
                    .ForMember(c => c.UserDetail.BirthDate, map => map.MapFrom(m => m.BirthDate));
        }
    }
}
