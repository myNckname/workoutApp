using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WorkoutApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService service)
        { 
            _service = service;
        }

        [HttpPost]
        public async Task<string> Login(CredentialsDto credentials)
        {
           return await _service.Login(credentials);
        }
        [HttpPost("registration")]
        public async Task Register(UserDto user)
        {
            await _service.Register(user);
        }
        [Authorize]
        [HttpGet]
        public async Task<UserDto> Get()
        {
            return await _service.GetUserPreferences();
        }
    }
}
