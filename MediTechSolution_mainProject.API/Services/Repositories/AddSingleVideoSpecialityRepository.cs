using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddSingleVideoSpecialityRepository : ISingleVideoSpeciality
    {
        private readonly ApplicatinDbContext dbContext;

        public AddSingleVideoSpecialityRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SingleSpecialityVideo> CreateSingleVideoSpecialityAsync(SingleSpecialityVideo singleSpecialityVideo)
        {
            await dbContext.SingleSpecialityVideos.AddAsync(singleSpecialityVideo);
            await dbContext.SaveChangesAsync();

            return singleSpecialityVideo;
        }

        public async Task<SingleSpecialityVideo> DeleteSingleVideoSpecialityByIdAsync(int id)
        {
            var existId = await dbContext.SingleSpecialityVideos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existId == null)
            {
                return null;
            }

            dbContext.SingleSpecialityVideos.Remove(existId);
            dbContext.SaveChangesAsync();
            return existId;
        }

        public async Task<List<SingleSpecialityVideo>> GetAllSingleVideoSpecialityAsync()
        {
            return await dbContext.SingleSpecialityVideos.Include(x => x.MedicalDoctorSpeciality).ToListAsync();
        }

        public async Task<SingleSpecialityVideo> GetSingleVideoSpecialityByIdAsync(int id)
        {
            var existId = await dbContext.SingleSpecialityVideos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existId == null)
            {
                return null;
            }
            return existId;
        }
    }
}
