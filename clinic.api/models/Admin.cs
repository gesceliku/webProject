using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Admin
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
    }
}
