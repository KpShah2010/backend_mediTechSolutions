using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IHospitalsLocations
    {
        Task<AddHospitalsLocations> CreateHospitalsLocationAsync(AddHospitalsLocations addHospitalsLocations);
        Task<List<AddHospitalsLocations>> GetAllHospitalsLocationAsync();
        Task<AddHospitalsLocations> GetHospitalsLocationByIdAsync(int id);
        Task<AddHospitalsLocations> DeleteHospitalsLocationAsync(int id);
        Task<AddHospitalsLocations> UpdateHospitalsLocationAsync(AddHospitalsLocations addHospitalsLocations);
    }
}
