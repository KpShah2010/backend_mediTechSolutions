using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddHelpDesksRepository : IHelpDesk
    {
        private readonly ApplicatinDbContext dbContext;

        public AddHelpDesksRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddHelpDeskModel> AddHelpDeskModelAsync(AddHelpDeskModel addHelpDeskModel)
        {
            await dbContext.AddHelpDesks.AddAsync(addHelpDeskModel);
            await dbContext.SaveChangesAsync();
            return addHelpDeskModel;
        }

        public async Task<AddHelpDeskModel> DeletehelpDeskModelAsync(int id)
        {
            var existingId = await dbContext.AddHelpDesks.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }
            dbContext.AddHelpDesks.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<AddHelpDeskModel>> GetAllAddHelpDeskModelAsync()
        {
            return await dbContext.AddHelpDesks.ToListAsync();
        }

        public async Task<AddHelpDeskModel> UpdateHelpDesksModelAsync(int id, AddHelpDeskModel addHelpDeskModel)
        {
            var existingId = await dbContext.AddHelpDesks.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.Issues = addHelpDeskModel.Issues;
            existingId.DocId = addHelpDeskModel.DocId;
            await dbContext.SaveChangesAsync();
            return existingId;
        }
    }
}
