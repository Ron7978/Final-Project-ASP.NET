using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Rides_Ordered
    {
        [Key]
        public int Id { get; set; }
        public string Driver_Name { get; set; }
        public string email { get; set; }
        public string pickup_location { get; set; }
        public string drop_location { get; set; }
        public int price { get; set; }
    }
}

