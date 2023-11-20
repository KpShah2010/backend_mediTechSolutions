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

        public async Task<MedicalDoctorSpeciality> DeleteMedicalSpeciality(int id)
        {
            var existingId = await dbContext.MedicalDoctorSpecialities.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.MedicalDoctorSpecialities.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public Task<List<MedicalDoctorSpeciality>> GetAllMedicalSpecialityAsync()
        {
            return dbContext.MedicalDoctorSpecialities.OrderByDescending(x => x.Id).Take(6).ToListAsync();
        }

        public async Task<MedicalDoctorSpeciality> GetMedicalSpecialityByIdAsync(int id)
        {
            var existId = await dbContext.MedicalDoctorSpecialities.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existId == null)
            {
                return null;
            }

            return existId;
        }

        public async Task<MedicalDoctorSpeciality> UpdateMedicalSpecialityAsync(int id, MedicalDoctorSpeciality medicalDoctorSpeciality)
        {
            var existingId = await dbContext.MedicalDoctorSpecialities.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.SpecialityName = medicalDoctorSpeciality.SpecialityName;
            existingId.SpecialityImage = medicalDoctorSpeciality.SpecialityImage;
            await dbContext.SaveChangesAsync();

            return existingId;
        }
    }
}
