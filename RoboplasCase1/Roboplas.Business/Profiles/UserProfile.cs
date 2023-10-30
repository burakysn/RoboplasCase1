using AutoMapper;
using Roboplas.Model.Dtos.User;
using Roboplas.Model.Entities;

namespace Roboplas.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPostDto, User>();
        }
    }
}
