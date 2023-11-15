using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class DoctorLoginRepository : IDoctorLogin
    {
        private readonly ApplicatinDbContext dbContext;

        public DoctorLoginRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Doctor DoctorLoginAuthenticate(string username, string password, string licenseNumber)
        {
            var doctor = dbContext.Doctors.SingleOrDefault(d => d.Username == username 
                && d.Password == password 
                && d.LicenseNumber == licenseNumber);
            return doctor;
        }
    }
}
