using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Workout: BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
