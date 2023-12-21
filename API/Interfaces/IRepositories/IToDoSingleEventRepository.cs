using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;

namespace API.Interfaces.IRepositories
{
    public interface IToDoSingleEventRepository
    {
        Task<ToDoSingleEventResponseDto> CreateToDoSingleEvent(ToDoSingleEventRequestDto todoser, User user);
        Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtos();
        Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtosByDate(DateOnly date);
        Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtosByEventName(string eventName);

        Task<ToDoSingleEventResponseDto> DeleteToDoSingleEvent(ToDoUniqueSingleEventRequestDto todousr,User user);

    }
}