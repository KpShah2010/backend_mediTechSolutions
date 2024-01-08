using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class SlotsRepository : ISlots
    {
        private readonly ApplicatinDbContext dbContext;

        public SlotsRepository(ApplicatinDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }


        public async Task<Slots> CreateSlotsAsync(Slots slots)
        {
            await dbContext.Slots.AddAsync(slots);
            await dbContext.SaveChangesAsync();
            return slots;
        }

        public async Task<List<Slots>> DateWiseSlots(DateTime date)
        {
            return await dbContext.Slots
                .Where(x => x.Date == date)
                .ToListAsync();
        }

        public async Task<List<Slots>> GetAllSlotsAsync()
        {
            return await dbContext.Slots.ToListAsync();
        }

        public async Task<Slots> GetSlotsByIdAsync(int id)
        {
            var existingId = await dbContext.Slots.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }
    }
}
