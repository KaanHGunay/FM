using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Stadium> Stadium { get; set; }
    }
}
