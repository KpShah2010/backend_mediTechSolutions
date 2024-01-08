using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class ReplyToPatientsRepository : IReplyToPatients
    {
        private readonly ApplicatinDbContext dbContext;

        public ReplyToPatientsRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ReplyToPatientsModel> CreateReplyTopatientsAsync(ReplyToPatientsModel replyToPatientsModel)
        {
            await dbContext.ReplyToPatientsModels.AddAsync(replyToPatientsModel);
            await dbContext.SaveChangesAsync();

            return replyToPatientsModel;
        }

        public Task<List<ReplyToPatientsModel>> GetAllReplyTopatientsAsync()
        {
            return dbContext.ReplyToPatientsModels.Include(u => u.User).ToListAsync();
        }
    }
}
