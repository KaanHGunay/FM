using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class Footballer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Country Country { get; set; }
        public Team Team { get; set; }
        public Position Position { get; set; }
    }
}
