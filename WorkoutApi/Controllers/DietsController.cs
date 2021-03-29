using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietsController:ControllerBase
    {
        private readonly IDietsService _service;
        private readonly IMapper _mapper;
        public DietsController(IDietsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DietDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<DietDto>>(await _service.GetAllAsync());
        }
        [Authorize]
        [HttpGet("my")]
        public async Task<IEnumerable<DietDto>> GetUsersWorkouts()
        {
            return _mapper.Map<IEnumerable<DietDto>>(await _service.GetUsersDiet());
        }
    }
}
