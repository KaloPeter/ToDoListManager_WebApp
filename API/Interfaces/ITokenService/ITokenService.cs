using API.Entities;

namespace API.Interfaces.ITokenService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}