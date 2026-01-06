
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class AppointmentService
    {
        private AppDbContext _context;
        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Appointments>> GetAppointmentByClientAsync(string clientUn)
        {
            return await _context.Appointments.Where(p => p.ClientUsername.Equals(clientUn, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
        public async Task<List<Appointments>> GetAppointmentByDoctorAsync(string doctorUn)
        {
            return await _context.Appointments.Where(p => p.DoctorUsername.Equals(doctorUn, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task CreateAppointmentAsync(Appointments newAppointment)
        {

            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentByIdAsync(int appointmentId)
        {
            var appointmentDb = await _context.Appointments.FirstOrDefaultAsync(a => a.Id.Equals(appointmentId));
            if (appointmentDb != null)
            {
                _context.Appointments.Remove(appointmentDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
