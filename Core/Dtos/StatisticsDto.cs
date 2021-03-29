using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class StatisticsDto
    {
        public DateTime Date { get; set; }
        public int CaloriesCount { get; set; }
        public int ExcersiesCount { get; set; }
    }
}
