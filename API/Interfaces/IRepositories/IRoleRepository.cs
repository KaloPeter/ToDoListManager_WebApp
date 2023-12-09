using API.DTOs.ResponseDto;
using API.Entities;

namespace API.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        /*Create Role*/

        Task<IEnumerable<RoleResponseDto>> GetRoleDtos();
        Task<IEnumerable<Role>> GetRoles();

    }
}