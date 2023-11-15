using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class MediceneCategoryRepository : IMediceneCategory
    {
        private readonly ApplicatinDbContext dbContext;

        public MediceneCategoryRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MediceneCategory> CreateMediceneCategoryAsync(MediceneCategory mediceneCategory)
        {
            await dbContext.MediceneCategory.AddAsync(mediceneCategory);
            await dbContext.SaveChangesAsync();
            return mediceneCategory;
        }

        public async Task<MediceneCategory> DeleteMediceneCategoryAsync(int id)
        {
            var existingId = await dbContext.MediceneCategory.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.MediceneCategory.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<MediceneCategory>> GetMediceneCategoryAsync()
        {
            return await dbContext.MediceneCategory.ToListAsync();
        }

        public async Task<MediceneCategory> GetMediceneCategoryByIdAsync(int id)
        {
            var existingId = await dbContext.MediceneCategory.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }
    }
}
