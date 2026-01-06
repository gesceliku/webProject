using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>()
                .HasOne(b => b.clients)
                .WithMany(ba => ba.Appointments)
                .HasForeignKey(bi => bi.ClientUsername);

            modelBuilder.Entity<Appointments>()
                .HasOne(b => b.doctors)
                .WithMany(ba =>ba.Appointments)
                .HasForeignKey(bi => bi.DoctorUsername);
        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Admin> Admin { get; set; }
        
    }
}
