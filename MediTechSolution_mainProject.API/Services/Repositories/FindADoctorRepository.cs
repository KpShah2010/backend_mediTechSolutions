using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class FindADoctorRepository : IFindADoctor
    {
        private readonly ApplicatinDbContext dbContext;

        public FindADoctorRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FindADoctor> CreateAsync(FindADoctor findADoctor)
        {
            await dbContext.FindDoctors.AddAsync(findADoctor);
            await dbContext.SaveChangesAsync();
            return findADoctor;
        }

        public async Task<List<FindADoctor>> GetAllAsync()
        {
            return await dbContext.FindDoctors.Include(x => x.MedicalDoctorSpeciality).Include(x => x.Doctor).ToListAsync();
        }

        public async Task<FindADoctor> GetByIdAsync(int id)
        {
            var existingId = await dbContext.FindDoctors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingId == null)
            {
                return null;
            }
            return existingId;
        }
    }
}
