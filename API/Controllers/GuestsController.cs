using System.Net.Http.Headers;
using System.Security.Claims;
using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Interfaces.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [Authorize]
    public class GuestsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IToDoSingleEventRepository _toDoSingleRepository;
        private readonly ITodoRangedEventRepository _toDoRangedRepository;
        public GuestsController(IUserRepository userRepository, IToDoSingleEventRepository todoSingleRepository, ITodoRangedEventRepository toDoRangedRepository)
        {
            this._toDoRangedRepository = toDoRangedRepository;
            this._toDoSingleRepository = todoSingleRepository;
            this._userRepository = userRepository;
        }


        // [HttpPost("upload2")]
        // public IActionResult Upload2([FromForm] ToDoSingleEventRequestDto tdr)
        // {

        //     var folderName = Path.Combine("Resources", "Images");
        //     var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //     if (tdr.ToDoImage.Length > 0)
        //     {
        //         var fileName = ContentDispositionHeaderValue.Parse(tdr.ToDoImage.ContentDisposition).FileName.Trim('"');
        //         var fullPath = Path.Combine(pathToSave, fileName);
        //         var dbPath = Path.Combine(folderName, fileName);
        //         using (var stream = new FileStream(fullPath, FileMode.Create))
        //         {
        //             tdr.ToDoImage.CopyTo(stream);
        //         }
        //         return Ok(tdr);
        //     }
        //     else
        //     {
        //         return BadRequest();
        //     }


        // }


        [HttpPost("add-todosingleevent")]
        public async Task<ActionResult<ToDoSingleEventResponseDto>> AddToDoSingleEvent(/*[FromForm]*/ ToDoSingleEventRequestDto todose)
        {
            ;
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userName == null) return NotFound();
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null) return NotFound("User not found in database");


            var todoSingle = await _toDoSingleRepository.CreateToDoSingleEvent(todose, user);

            return todoSingle;
        }


        [HttpPost("add-todorangedevent")]
        public async Task<ActionResult<ToDoRangedEventResponseDto>> AddToDoRangedEvent(ToDoRangedEventRequestDto todorer)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userName == null) return NotFound();
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null) return NotFound("User not found in database");

            var todoRanged = await _toDoRangedRepository.CreateToDoRangedEvent(todorer, user);
            return todoRanged;
        }

        [HttpDelete("delete-todosingleevent")]
        public async Task<ActionResult<ToDoSingleEventResponseDto>> DeleteToDoSingleEvent(ToDoUniqueSingleEventRequestDto todorr)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userName == null) return NotFound();
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null) return NotFound("User not found in database");


            return await _toDoSingleRepository.DeleteToDoSingleEvent(todorr, user);
        }


        [HttpDelete("delete-todorangedevent")]
        public async Task<ActionResult<ToDoRangedEventResponseDto>> DeleteToDoRangedEvent(ToDoUniqueRangedEventRequestDto todorr)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userName == null) return NotFound();
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null) return NotFound("User not found in database");


            return await _toDoRangedRepository.DeleteToDoRangedEvent(todorr, user);
        }





    }
}