using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Driver_Details
    {
        [Key]
        public int DriverId { get; set; }
        public string Driver_Name { get; set; }
        public string email { get; set; }
        public string Driver_location { get; set; }
        public int? travel_id { get; set; }
        public int? price { get; set; }
    }
}
