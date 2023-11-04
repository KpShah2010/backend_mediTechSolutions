using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class MedicalSpecialityRepository : IMedicalSpeciality
    {
        private readonly ApplicatinDbContext dbContext;

        public MedicalSpecialityRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MedicalDoctorSpeciality> CreateMedicalSpecialityAsync(MedicalDoctorSpeciality medicalSpeciality)
        {
            await dbContext.MedicalDoctorSpecialities.AddAsync(medicalSpeciality);
            await dbContext.SaveChangesAsync();
            return medicalSpeciality;
        }

        public Task<List<MedicalDoctorSpeciality>> GetAllMedicalSpecialityAsync()
        {
            return dbContext.MedicalDoctorSpecialities.OrderByDescending(x => x.Id).Take(6).ToListAsync();
        }
    }
}
