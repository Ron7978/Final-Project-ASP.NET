using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Passengers
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string pickup { get; set; }
        public string drop { get; set; }
        public int price { get; set; }
    }
}
