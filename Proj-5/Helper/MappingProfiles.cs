using AutoMapper;
using Proj_5.Dto;
using Proj_5.Models;
namespace Proj_5.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
