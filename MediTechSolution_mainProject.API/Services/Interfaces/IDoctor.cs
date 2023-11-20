using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IDoctor
    {
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<List<Doctor>> GetAllDoctorAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<List<Doctor>> GetDoctorByName(string name);
        Task<Doctor> UpdateDoctorAsync(int id, bool isAccepted);
        Task<Doctor> DeleteDoctorAsync(int id);
    }
}
