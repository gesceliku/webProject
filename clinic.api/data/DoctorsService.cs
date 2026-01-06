using System.Linq;
using DentalClinic.Dtos.Responses;
using DentalClinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class DoctorsService
    {
        private AppDbContext _context;
        public DoctorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doctors>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctors> GetDoctorByUsernameAsync(string doctorUn)
        {
            var doctorDb = _context.Doctors
                .FirstOrDefault(a => a.username.Equals(doctorUn));

            return doctorDb;
        }
        public async Task< List<Doctors>> GetDoctorsByClinicAsync(string clinic)
        {
            return await _context.Doctors.Where(p => p.clinic.Equals(clinic, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
        public async Task AddNewDoctorAsync(Doctors newDoctor)
        {

            await _context.Doctors.AddAsync(newDoctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorByUsernameAsync(string doctorUn)
        {
            var doctorDb = await _context.Doctors.FirstOrDefaultAsync(a => a.username.Equals(doctorUn));
            if (doctorDb != null)
            {
                _context.Doctors.Remove(doctorDb);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateDoctorByUsernameAsync(string doctorUn, Doctors updatedDoctor)
        {
            var doctorDb = await _context.Doctors.FirstOrDefaultAsync(a => a.username.Equals(doctorUn));
            if (doctorDb != null)
            {
                doctorDb.name = updatedDoctor.name;
                _context.Doctors.Update(doctorDb);
               await  _context.SaveChangesAsync();
            }
        }
    }
}
