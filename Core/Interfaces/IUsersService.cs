using Core.Dtos;
using DAL.Models;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<string> Login(CredentialsDto credentials);
        Task Register(UserDto userDto);
        Task<UserDto> GetUserPreferences();
    }
}
