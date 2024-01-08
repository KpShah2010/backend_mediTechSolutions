using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISendingRequestToDoctor
    {
        Task<SendingRequestToDoctor> SendToDoctorAsync(SendingRequestToDoctor sendingRequestToDoctor);
        Task<List<SendingRequestToDoctor>> GetAllSendToDoctorAsync();
    }
}
