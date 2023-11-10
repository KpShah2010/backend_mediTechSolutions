using MediTechSolution_mainProject.API.Model;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Data
{
    public class ApplicatinDbContext : DbContext
    {
        public ApplicatinDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AddHospitalCityNames> AddHospitalCityNames { get; set; }
        public DbSet<MedicalDoctorSpeciality> MedicalDoctorSpecialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<CollegesModel> Colleges { get; set; }
        public DbSet<CourseDetailsModel> CourseDetails { get; set; }
        public DbSet<FindADoctor> FindDoctors { get; set; }
        public DbSet<AddAppointmentToClient> AppointmentToClient { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
    }
}