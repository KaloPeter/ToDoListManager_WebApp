using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs.RequestDto;
using API.DTOs.ResponseDto;
using API.Entities;
using API.Interfaces.ITokenService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AccountsController : ControllerBase
    {

        private readonly TodoDataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountsController(TodoDataContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserTokenResponseDto>> Register(UserRegisterRequestDto urrdto)
        {
            if (urrdto == null)
            {
                return BadRequest("Inputs are Empty!");
            }


            if (await _context.Users.AnyAsync(u => u.Email == urrdto.Email))
            {
                return BadRequest("Email already exists in database");//CHANGE
            }

            if (await _context.Users.AnyAsync(u => u.UserName == urrdto.UserName))
            {
                return BadRequest("UserName already exists in database");//CHANGE
            }

            GeneratePassword(urrdto.Password, out byte[] PasswordSalt, out byte[] PasswordHash);

            var user = _mapper.Map<User>(urrdto);

            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            //I have to get the RoleObject, and NotRoleId to get access to role in automapper, so when I return with DTO, i can set its value.
            user.Role = await _context.Roles.Where(r => r.RoleName == "Guest").FirstOrDefaultAsync();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var muser = _mapper.Map<UserTokenResponseDto>(user);
            muser.Token = _tokenService.CreateToken(user);

            return muser;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserTokenResponseDto>> Login(LoginRequestDto lrdto)
        {
            //To get rolename using automapper, i have to include here the role, to get accesss to its name.
            var user = await _context.Users.Where(u => u.UserName == lrdto.UserName).Include(u => u.Role).FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest("Invalid Username or Password");
            }

            if (!VerifyPassword(lrdto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Invalid Username or Password");
            }

            var loggedUser = _mapper.Map<UserTokenResponseDto>(user);
            loggedUser.Token = _tokenService.CreateToken(user);

            return loggedUser;

        }


        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private void GeneratePassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
        }
    }
}