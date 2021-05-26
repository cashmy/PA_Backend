using AutoMapper;
using PA_Backend.DataTransferObjects;
using PA_Backend.Models;

namespace PA_Backend.Managers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
