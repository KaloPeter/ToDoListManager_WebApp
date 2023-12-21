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
            //Left is mapped -> to the right one
            CreateMap<UserRegisterRequestDto, User>();
            CreateMap<User, UserTokenResponseDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));


            CreateMap<ToDoSingleEventRequestDto, ToDoSingleEvent>();
            CreateMap<ToDoSingleEvent, ToDoSingleEventResponseDto>();

            CreateMap<ToDoRangedEventRequestDto, ToDoRangedEvent>();
            CreateMap<ToDoRangedEvent, ToDoRangedEventResponseDto>();


        }
    }
}