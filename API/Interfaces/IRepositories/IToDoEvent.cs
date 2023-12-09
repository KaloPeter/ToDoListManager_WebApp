using API.DTOs.ResponseDto;

namespace API.Interfaces.IRepositories
{
    public interface IToDoEvent
    {
        Task<ToDoEventResponseDto> CreateToDoEvent(/*request object dto*/);

        Task<IEnumerable<ToDoEventResponseDto>> GetToDoEventDtos();
        Task<IEnumerable<ToDoEventResponseDto>> GetToDoEventDtosByDate(DateOnly date);
        Task<IEnumerable<ToDoEventResponseDto>> GetToDoEventDtosByEventName(string eventName);


    }
}