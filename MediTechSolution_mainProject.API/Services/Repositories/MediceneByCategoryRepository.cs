using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class MediceneByCategoryRepository : IMediceneByCategory
    {
        private readonly ApplicatinDbContext dbContext;

        public MediceneByCategoryRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MediceneByCategory> CreateMediceneByCategoryAsync(MediceneByCategory mediceneByCategory)
        {
            await dbContext.MediceneByCategory.AddAsync(mediceneByCategory);
            await dbContext.SaveChangesAsync();

            return mediceneByCategory;
        }

        public async Task<MediceneByCategory> DeleteMediceneByCategoryAsync(int id)
        {
            var existingId = await dbContext.MediceneByCategory.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.MediceneByCategory.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<MediceneByCategory>> GetAllMediceneByCategoryAsync()
        {
            return await dbContext.MediceneByCategory.Include(x => x.MediceneCategory).ToListAsync();
        }

        public async Task<MediceneByCategory> GetMediceneByCategoryByIdAsync(int id)
        {
            var existingId = await dbContext.MediceneByCategory.Include(x => x.MediceneCategory)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if(existingId == null) 
            {
                return null;
            }
            return existingId;
        }

        public async Task<MediceneByCategory> UpdateMediceneCategoryAsync(int id, MediceneByCategory mediceneByCategory)
        {
            var existingId = await dbContext.MediceneByCategory.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.MediceneName = mediceneByCategory.MediceneName;
            existingId.MedicenePrescription = mediceneByCategory.MedicenePrescription;
            existingId.MediceneRelated = mediceneByCategory.MediceneRelated;
            existingId.SideEffect = mediceneByCategory.SideEffect;
            existingId.MediceneCategoryId = mediceneByCategory.MediceneCategoryId;

            await dbContext.SaveChangesAsync();
            return existingId;
        }
    }
}