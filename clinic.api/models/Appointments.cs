namespace DentalClinic.Models
{
    public class Appointments
    {
       public int Id { get; set; }
        public string ClientUsername { get; set; }
        public Clients clients { get; set; }
        public string DoctorUsername { get; set; }
        public Doctors doctors { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string clinic {  get; set; }


    }
}
