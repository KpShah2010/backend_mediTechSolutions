using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class CollegeUniversityRepository : ICollegesUniversity
    {
        private readonly ApplicatinDbContext dbContext;

        public CollegeUniversityRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CollegesModel> CreateCollegesUniversityAsync(CollegesModel collegesModel)
        {
            await dbContext.Colleges.AddAsync(collegesModel);
            await dbContext.SaveChangesAsync();

            return collegesModel;
        }

        public async Task<List<CollegesModel>> GetAllCollegesUniversities()
        {
            return await dbContext.Colleges.ToListAsync();
        }

        public async Task<CollegesModel> GetCollegesUniversitiesById(int id)
        {
            var existingId = await dbContext.Colleges.FirstOrDefaultAsync(x => x.Id == id);

            if (existingId == null)
            { 
                return null;
            }

            return existingId;
        }
    }
}
