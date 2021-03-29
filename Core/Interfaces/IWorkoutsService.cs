using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IWorkoutsService:IDefaultService<Workout>
    {
        Task<IEnumerable<UserWorkout>> GetUsersWorkouts();
        Task CreateUserWorkout(UserWorkout userWorkout);
    }
}
