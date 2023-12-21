using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;

namespace API.Interfaces.IRepositories
{
    public interface ITodoRangedEventRepository
    {
        Task<ToDoRangedEventResponseDto> CreateToDoRangedEvent(ToDoRangedEventRequestDto todorer, User user);
        Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtos();
        Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtosByDate(DateOnly date);
        Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtosByEventName(string eventName);

        Task<ToDoRangedEventResponseDto> DeleteToDoRangedEvent(ToDoUniqueRangedEventRequestDto todorr, User user);
    }
}