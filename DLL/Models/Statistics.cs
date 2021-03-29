using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Statistics:BaseEntity
    {
        public DateTime Date { get; set; }
        public int CaloriesCount { get; set; }
        public int ExcersiesCount { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
