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
    public class DietsService : IDietsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Context _context;
        public DietsService(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<IEnumerable<Diet>> GetAllAsync()
        {
            return await _context.Diets.ToListAsync();
        }

        public async Task<Diet> GetByIdAsync(int id)
        {
            return await _context.Diets.FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<Diet> GetUsersDiet()
        {
            var userEmail = _httpContextAccessor.GetCurrenUserEmail();
            var user =  await _context.Users.Include(u=>u.Diet).FirstOrDefaultAsync(w => w.Email.Equals(userEmail));
            return user.Diet;
        }
    }
}
