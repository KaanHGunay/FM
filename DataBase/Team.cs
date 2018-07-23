using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class Team
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public League League { get; set; }
        public City City { get; set; }
        public Stadium Stadium { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        [Required]
        public Manager Manager { get; set; }
    }
}
