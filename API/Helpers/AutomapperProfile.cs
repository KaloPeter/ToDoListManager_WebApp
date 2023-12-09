using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserRegisterRequestDto, User>();
            CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));




        }
    }
}