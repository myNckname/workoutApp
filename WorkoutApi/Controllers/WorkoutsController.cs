using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutsService _service;
        private readonly IMapper _mapper;
        public WorkoutsController(IWorkoutsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WorkoutDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<WorkoutDto>>(await _service.GetAllAsync());
        }
        [Authorize]
        [HttpGet("my")]
        public async Task<IEnumerable<UserWorkoutDto>> GetUsersWorkouts()
        {
            return _mapper.Map<IEnumerable<UserWorkoutDto>>(await _service.GetUsersWorkouts());
        }
        [Authorize]
        [HttpPost]
        public async Task Create(UserWorkoutDto userWorkoutDto)
        {
            await _service.CreateUserWorkout(_mapper.Map<UserWorkout>(userWorkoutDto));
        }
    }
}
