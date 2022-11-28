using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Distance
    {
        [Key]
        public int Id { get; set; }
        public string location1 { get; set; }
        public string location2 { get; set; }
        public int distance { get; set; }
        public int price { get; set; }
    }
}
