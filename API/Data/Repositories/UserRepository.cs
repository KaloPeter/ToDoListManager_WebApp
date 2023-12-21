using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.ResponseDto;
using API.Entities;
using API.Interfaces.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(TodoDataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }


        public async Task<User> GetUserByUserName(string username)
        {
            return await _context.Users.Include(ur => ur.Role).FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<UserResponseDto> GetUserDtoByUserName(string username)
        {
            return await _context.Users.Where(u => u.UserName == username).ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserResponseDto>> GetUserDtos()
        {
            return await _context.Users.ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}