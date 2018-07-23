using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class League
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
