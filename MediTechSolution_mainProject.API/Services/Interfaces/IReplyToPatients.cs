using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IReplyToPatients
    {
        Task<ReplyToPatientsModel> CreateReplyTopatientsAsync(ReplyToPatientsModel replyToPatientsModel);
        Task<List<ReplyToPatientsModel>> GetAllReplyTopatientsAsync();
    }
}
