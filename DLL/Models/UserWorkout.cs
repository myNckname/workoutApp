using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserWorkout:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int SpentTime { get; set; }
        public int SpentCalories { get; set; }
    }
}
