using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class AdminService
    {
        private AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetAdminByUsernameAsync(string adminUn)
        {
            var adminDb = await _context.Admin

                .FirstOrDefaultAsync(a => a.username.Equals(adminUn));

            return adminDb;
        }

        public async Task AddNewAdminAsync(Admin newAdmin)
        {

            await _context.Admin.AddAsync(newAdmin);
            await _context.SaveChangesAsync();
        }

    }
}
