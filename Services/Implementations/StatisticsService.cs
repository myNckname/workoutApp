using Core.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utils;
namespace Services.Implementations
{
    public class StatisticsService : IStatisticsService
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatisticsService(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Statistics>> GetUserStatistics()
        {
            var userEmail = _httpContextAccessor.GetCurrenUserEmail();
            var user =await _context.Users.Include(u => u.Statistics).FirstOrDefaultAsync(u => u.Email.Equals(userEmail));
            return user.Statistics;
        }
    }
}
