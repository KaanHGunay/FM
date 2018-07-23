using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class Continent
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
