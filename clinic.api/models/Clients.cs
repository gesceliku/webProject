using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Models
{
    public class Clients
    {
        [Key] 
        public string username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public List<Appointments> Appointments { get; set; }
       

    }
}
