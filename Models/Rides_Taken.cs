using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Rides_Taken
    {
        [Key]
        public int id { get; set; }
        public string Customer_name { get; set; }
        public string email { get; set; }
        public string pickup_location { get; set; }
        public string drop_location { get; set; }
        public int price { get; set; }
        public int travel_id { get; set; }
    }
}
