using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class Position
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Footballer> Footballers { get; set; }
    }
}
