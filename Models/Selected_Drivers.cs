using System.ComponentModel.DataAnnotations;

namespace Cab_Project.Models
{
    public class Selected_Drivers
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
    }
}
