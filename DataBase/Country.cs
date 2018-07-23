using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class Country
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Continent Continent { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<League> Leagues { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }
}
