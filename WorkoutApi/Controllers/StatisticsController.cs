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
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;
        private readonly IMapper _mapper;
        public StatisticsController(IStatisticsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<StatisticsDto>> Get()
        {
            return _mapper.Map<IEnumerable<StatisticsDto>>(await _service.GetUserStatistics());
        }
    }
}
