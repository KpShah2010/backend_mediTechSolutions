using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISendingRequestToDoctor
    {
        Task<SendingRequestToDoctor> AddSendingRequestToDoctorAsync(SendingRequestToDoctor sendingRequestToDoctor);

        Task<List<SendingRequestToDoctor>> GetALlSendingRequestAsync();
    }
}
