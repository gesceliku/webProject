using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Doctors
    {
        [Key]
        public string username { get; set; }
        public string name { get; set; }
        public string clinic {  get; set; }
        
        public string password { get; set; }
        public List<Appointments> Appointments { get; set; }
        


    }
}
