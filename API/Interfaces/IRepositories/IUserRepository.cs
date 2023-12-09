using API.DTOs.ResponseDto;
using API.Entities;

namespace API.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponseDto>> GetUserDtos();
        Task<UserResponseDto> GetUserDtoByUserName(string username);
        Task<User> GetUserByUserName(string username);




    }
}