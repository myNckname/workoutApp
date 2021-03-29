using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Diet:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
