using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;
using API.Interfaces.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ToDoRangedEventRepository : ITodoRangedEventRepository
    {
        private readonly IMapper _mapper;
        private readonly TodoDataContext _context;
        public ToDoRangedEventRepository(TodoDataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;

        }

        public async Task<ToDoRangedEventResponseDto> CreateToDoRangedEvent(ToDoRangedEventRequestDto todorer, User user)
        {
            var toDoRangedEvent = _mapper.Map<ToDoRangedEvent>(todorer);
            toDoRangedEvent.User = user;

            _context.ToDoRangedEvents.Add(toDoRangedEvent);

            await _context.SaveChangesAsync();

            var respToDoRangedEvent = _mapper.Map<ToDoRangedEventResponseDto>(toDoRangedEvent);

            return respToDoRangedEvent;

        }

        public async Task<ToDoRangedEventResponseDto> DeleteToDoRangedEvent(ToDoUniqueRangedEventRequestDto todorr, User user)
        {
            var removeableEvent = await _context.ToDoRangedEvents.FirstOrDefaultAsync(re =>
            re.ToDoRangedEventName == todorr.ToDoRangedEventName
            && re.RangedEventImportance == todorr.RangedEventImportance
            && re.RangedEventStartDate == todorr.RangedEventStartDate
            && re.RangedEventEndDate == todorr.RangedEventEndDate);

            removeableEvent.User = user;

            _context.ToDoRangedEvents.Remove(removeableEvent);

            await _context.SaveChangesAsync();

            return _mapper.Map<ToDoRangedEventResponseDto>(removeableEvent);

        }

        public async Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtos()
        {
            return await _context.ToDoRangedEvents.ProjectTo<ToDoRangedEventResponseDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtosByDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoRangedEventResponseDto>> GetToDoRangedEventDtosByEventName(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}