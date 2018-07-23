using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    class SupporterGroup
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Team Team { get; set; }
    }
}
