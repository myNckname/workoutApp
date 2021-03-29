using Core.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utils;
using System.Linq;
using Core.Dtos;
using System;

namespace Services.Implementations
{
    public class WorkoutsService : IWorkoutsService
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WorkoutsService(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            _context.SaveChanges();
            return await _context.Workouts.ToListAsync();

        }

        public async Task<Workout> GetByIdAsync(int id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(w=>w.Id==id);
        }

        public async Task<IEnumerable<UserWorkout>> GetUsersWorkouts()
        {
            var userEmail = _httpContextAccessor.GetCurrenUserEmail();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(userEmail));

            return await _context.UsersWorkouts.Include(u => u.Workout).Where(u => u.UserId == user.Id).ToListAsync();
        }
        public async Task CreateUserWorkout(UserWorkout userWorkout)
        {
            var userEmail = _httpContextAccessor.GetCurrenUserEmail();
            var user = await _context.Users.Include(s => s.Statistics).FirstOrDefaultAsync(u => u.Email.Equals(userEmail));
            var statistics = user.Statistics.Where(s => s.Date.CompareTo(DateTime.Now) == 0).FirstOrDefault();
            if (statistics == null)
                user.Statistics.Add(new Statistics { CaloriesCount = userWorkout.SpentCalories, ExcersiesCount = 1 });
            else
            {
                statistics.CaloriesCount += userWorkout.SpentCalories;
                statistics.ExcersiesCount++;
            }
            userWorkout.User = user;
            _context.Add(userWorkout);
            await _context.SaveChangesAsync();
        }
    }
}
