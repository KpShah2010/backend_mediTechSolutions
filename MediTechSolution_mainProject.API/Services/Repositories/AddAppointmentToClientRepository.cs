using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddAppointmentToClientRepository : IAppointmentToClient
    {
        private readonly ApplicatinDbContext dbContext;

        public AddAppointmentToClientRepository( ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddAppointmentToClient> CreateaddAppointmentToClientAsync(AddAppointmentToClient addAppointmentToClient)
        {
            await dbContext.AppointmentToClient.AddAsync(addAppointmentToClient);
            await dbContext.SaveChangesAsync();
            return addAppointmentToClient;
        }

        public async Task<AddAppointmentToClient> DeleteAppointmentToClientAsync(int id)
        {
            var existingId = await dbContext.AppointmentToClient.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.AppointmentToClient.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public Task<List<AddAppointmentToClient>> GetAllAppointmentToClientAsync()
        {
            return dbContext.AppointmentToClient.Include(x => x.Doctor).ToListAsync();
        }

        public async Task<AddAppointmentToClient> GetAppointmentToClientByIdAsync(int id)
        {
            var existingId = await dbContext.AppointmentToClient.Include(x => x.Doctor).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<AddAppointmentToClient> UpdateAppointmentToClientAsync(int id, AddAppointmentToClient addAppointmentToClient)
        {
            var existingId = await dbContext.AppointmentToClient.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.StartDate = addAppointmentToClient.StartDate;
            existingId.EndDate = addAppointmentToClient.EndDate;
            existingId.TimeSlotGap = addAppointmentToClient.TimeSlotGap;
            existingId.Price = addAppointmentToClient.Price;

            return existingId;
        }
    }
}
