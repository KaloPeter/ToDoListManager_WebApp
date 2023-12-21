using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;
using API.Interfaces.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ToDoSingleEventRepository : IToDoSingleEventRepository
    {

        private readonly TodoDataContext _context;
        private readonly IMapper _mapper;

        public ToDoSingleEventRepository(TodoDataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }

        public async Task<ToDoSingleEventResponseDto> CreateToDoSingleEvent(ToDoSingleEventRequestDto todoser, User user)
        {
            var toDoSingleEvent = _mapper.Map<ToDoSingleEvent>(todoser);
            toDoSingleEvent.User = user;

            _context.ToDoSingleEvents.Add(toDoSingleEvent);

            await _context.SaveChangesAsync();

            var respToDoSInglEvent = _mapper.Map<ToDoSingleEventResponseDto>(toDoSingleEvent);

            return respToDoSInglEvent;

        }

        public async Task<ToDoSingleEventResponseDto> DeleteToDoSingleEvent(ToDoUniqueSingleEventRequestDto todousr, User user)
        {
            var removeableEvent = await _context.ToDoSingleEvents.FirstOrDefaultAsync(re =>
            re.ToDoSingleEventName == todousr.ToDoSingleEventName
            && re.SingleEventImportance == todousr.SingleEventImportance
            && re.SingleEventDate == todousr.SingleEventDate);

            removeableEvent.User = user;

            _context.ToDoSingleEvents.Remove(removeableEvent);

            await _context.SaveChangesAsync();

            return _mapper.Map<ToDoSingleEventResponseDto>(removeableEvent);
        }

        public async Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtos()
        {
            return await _context.ToDoSingleEvents.ProjectTo<ToDoSingleEventResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtosByDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoSingleEventResponseDto>> GetToDoSingleEventDtosByEventName(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}