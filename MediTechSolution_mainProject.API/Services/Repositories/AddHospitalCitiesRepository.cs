using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddHospitalCitiesRepository : IHospitalCity
    {
        private readonly ApplicatinDbContext dbContext;

        public AddHospitalCitiesRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddHospitalCityNames> CreateHospitalCitiesAsync(AddHospitalCityNames addHospitalCityNames)
        {
            await dbContext.AddHospitalCityNames.AddAsync(addHospitalCityNames);
            await dbContext.SaveChangesAsync();

            return addHospitalCityNames;
        }

        public async Task<AddHospitalCityNames> DeleteHospitalsCitiesAsync(int id)
        {
            var existingId = await dbContext.AddHospitalCityNames.FirstOrDefaultAsync(x => x.Id == id);

            if(existingId == null) 
            {
                return null;
            }

            dbContext.AddHospitalCityNames.Remove(existingId);
            await dbContext.SaveChangesAsync();
            return existingId;
        }

        
        public async Task<List<AddHospitalCityNames>> GetAllHospitalsCitiesAsync()
        {
            return await dbContext.AddHospitalCityNames.ToListAsync();
        }

        public async Task<AddHospitalCityNames> GetSingleHospitalsCitiesAsync(int id)
        {
            var existingId = await dbContext.AddHospitalCityNames.FirstOrDefaultAsync(x => x.Id == id);

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<AddHospitalCityNames> UpdateHospitalsCitiesAsync(int id, AddHospitalCityNames addHospitalCityNames)
        {
            var existingId = await dbContext.AddHospitalCityNames.FirstOrDefaultAsync(x => x.Id == id);

            if (existingId == null)
            {
                return null;
            }

            existingId.Name = addHospitalCityNames.Name;
            existingId.Image = addHospitalCityNames.Image;

            await dbContext.SaveChangesAsync();
            return existingId;
        }
    }
}
