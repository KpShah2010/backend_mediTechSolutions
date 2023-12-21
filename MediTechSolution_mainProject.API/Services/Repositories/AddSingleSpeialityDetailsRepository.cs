using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddSingleSpeialityDetailsRepository : ISingleSpecialityDetails
    {
        private readonly ApplicatinDbContext dbContext;

        public AddSingleSpeialityDetailsRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddSingleSpecialityDetails> CreateSingleSpecialityDetailsAsync(AddSingleSpecialityDetails addSingleSpecialityDetails)
        {
            await dbContext.AddSingleSpecialityDetails.AddAsync(addSingleSpecialityDetails);
            await dbContext.SaveChangesAsync();
            return addSingleSpecialityDetails;
        }

        public async Task<AddSingleSpecialityDetails> DeleteSingleSpecialityDetailsAsync(int id)
        {
            var existingId = await dbContext.AddSingleSpecialityDetails.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.AddSingleSpecialityDetails.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<AddSingleSpecialityDetails>> GetAllSingleSpecialityDetailsAsync()
        {
            return await dbContext.AddSingleSpecialityDetails.Include(n => n.MedicalDoctorSpeciality).ToListAsync();
        }

        public async Task<AddSingleSpecialityDetails> GetSingleSpecialityDetailsByIdAsync(int id)
        {
            var existingId = await dbContext.AddSingleSpecialityDetails.Include(n => n.MedicalDoctorSpeciality).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<AddSingleSpecialityDetails> UpdateSingleSpecialityDetailsAsync(int id, AddSingleSpecialityDetails addSingleSpecialityDetails)
        {
            var existingId = await dbContext.AddSingleSpecialityDetails.Include(n => n.MedicalDoctorSpeciality).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.Description = addSingleSpecialityDetails.Description;
            existingId.Image = addSingleSpecialityDetails.Image;
            existingId.SId = addSingleSpecialityDetails.SId;

            return existingId;
        }
    }
}
