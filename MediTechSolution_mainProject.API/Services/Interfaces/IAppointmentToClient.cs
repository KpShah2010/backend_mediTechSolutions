using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IAppointmentToClient
    {
        Task<AddAppointmentToClient> CreateaddAppointmentToClientAsync(AddAppointmentToClient addAppointmentToClient);
        Task<List<AddAppointmentToClient>> GetAllAppointmentToClientAsync();
        Task<AddAppointmentToClient> GetAppointmentToClientByIdAsync(int id);
        Task<AddAppointmentToClient> DeleteAppointmentToClientAsync(int id);
        Task<AddAppointmentToClient> UpdateAppointmentToClientAsync(int id, AddAppointmentToClient addAppointmentToClient);
    }
}
