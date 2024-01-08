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
        public DbSet<MediceneCategory> MediceneCategory { get; set; }
        public DbSet<MediceneByCategory> MediceneByCategory { get; set; }
        public DbSet<AddHospitalsLocations> HospitalsLocations { get; set; }
        public DbSet<AddSingleSpecialityDetails> AddSingleSpecialityDetails { get; set; }
        public DbSet<SingleSpecialityVideo> SingleSpecialityVideos { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<AddHelpDeskModel> AddHelpDesk { get; set; }
        public DbSet<SendingRequestToDoctor> SendingRequestToDoctors { get; set; }
        public DbSet<ReplyToPatientsModel> ReplyToPatientsModels { get; set; }
        public DbSet<Slots> Slots { get; set; }
    }
}