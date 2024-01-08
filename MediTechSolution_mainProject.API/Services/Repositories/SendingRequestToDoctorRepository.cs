using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class SendingRequestToDoctorRepository : ISendingRequestToDoctor
    {
        private readonly ApplicatinDbContext dbContext;

        public SendingRequestToDoctorRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<SendingRequestToDoctor>> GetAllSendToDoctorAsync()
        {
            return await dbContext.SendingRequestToDoctors.Include(u => u.User).Include(d => d.Doctor).ToListAsync();
        }

        public async Task<SendingRequestToDoctor> SendToDoctorAsync(SendingRequestToDoctor sendingRequestToDoctor)
        {
            await dbContext.SendingRequestToDoctors.AddAsync(sendingRequestToDoctor);
            await dbContext.SaveChangesAsync();
            return sendingRequestToDoctor;
        }
    }
}
