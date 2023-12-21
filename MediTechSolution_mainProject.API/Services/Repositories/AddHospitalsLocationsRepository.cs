using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddHospitalsLocationsRepository : IHospitalsLocations
    {
        private readonly ApplicatinDbContext dbContext;

        public AddHospitalsLocationsRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddHospitalsLocations> CreateHospitalsLocationAsync(AddHospitalsLocations addHospitalsLocations)
        {
            await dbContext.HospitalsLocations.AddAsync(addHospitalsLocations);
            await dbContext.SaveChangesAsync();

            return addHospitalsLocations;
        }

        public async Task<AddHospitalsLocations> DeleteHospitalsLocationAsync(int id)
        {
            var existingId = await dbContext.HospitalsLocations.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.HospitalsLocations.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<AddHospitalsLocations>> GetAllHospitalsLocationAsync()
        {
            return await dbContext.HospitalsLocations.ToListAsync();
        }

        public async Task<AddHospitalsLocations> GetHospitalsLocationByIdAsync(int id)
        {
            var existingId = await dbContext.HospitalsLocations.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<AddHospitalsLocations> UpdateHospitalsLocationAsync(int id, AddHospitalsLocations addHospitalsLocations)
        {
            var existingId = await dbContext.HospitalsLocations.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.LocationName = addHospitalsLocations.LocationName;
            existingId.LocationLink = addHospitalsLocations.LocationLink;
            existingId.Address = addHospitalsLocations.Address;
            existingId.PhoneNumber = addHospitalsLocations.PhoneNumber;
            existingId.Image = addHospitalsLocations.Image;

            await dbContext.SaveChangesAsync();

            return existingId;
        }
    }
}