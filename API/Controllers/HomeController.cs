using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.ResponseDto;
using API.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class HomeController : ControllerBase
    {
        private readonly ITodoRangedEventRepository _toDoRangedRepository;
        private readonly IToDoSingleEventRepository _toDoSingleRepository;

        public HomeController(IToDoSingleEventRepository toDoSingleRepository, ITodoRangedEventRepository toDoRangedRepository)
        {
            this._toDoSingleRepository = toDoSingleRepository;
            this._toDoRangedRepository = toDoRangedRepository;
        }

        [HttpGet("get-todosingleevents")]
        public async Task<ActionResult<IEnumerable<ToDoSingleEventResponseDto>>> GetToDoSingleEvents()
        {
            return Ok(await _toDoSingleRepository.GetToDoSingleEventDtos());
        }

        [HttpGet("get-todorangedevents")]
        public async Task<ActionResult<IEnumerable<ToDoSingleEventResponseDto>>> GetToDoRangedEvents()
        {
            return Ok(await _toDoRangedRepository.GetToDoRangedEventDtos());
        }


    }
}