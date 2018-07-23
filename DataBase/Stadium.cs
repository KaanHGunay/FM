using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class Stadium
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public City City { get; set; }
        public ICollection<Team> Teams { get; set; }

    }
}
