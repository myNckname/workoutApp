using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserProfile UserProfile { get; set; }

        public int? DietId { get; set; }
        public Diet Diet { get; set; }

        public ICollection<Statistics> Statistics { get; set; } = new List<Statistics>();

        public ICollection<UserWorkout> UsersWorkouts { get; set; } = new List<UserWorkout>();
    }
}
