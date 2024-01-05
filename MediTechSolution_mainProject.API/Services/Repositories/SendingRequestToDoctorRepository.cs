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

        public async Task<SendingRequestToDoctor> AddSendingRequestToDoctorAsync(SendingRequestToDoctor sendingRequestToDoctor)
        {
            await dbContext.SendingRequestToDoctors.AddAsync(sendingRequestToDoctor);
            await dbContext.SaveChangesAsync();

            return sendingRequestToDoctor;
        }

        public async Task<List<SendingRequestToDoctor>> GetALlSendingRequestAsync()
        {
            return await dbContext.SendingRequestToDoctors.Include(u => u.User).Include(d => d.Doctor).ToListAsync();
        }
    }
}