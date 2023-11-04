using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IHospitalCity
    {
        Task<AddHospitalCityNames> CreateHospitalCitiesAsync(AddHospitalCityNames addHospitalCityNames);
        Task<List<AddHospitalCityNames>> GetAllHospitalsCitiesAsync();
        Task<AddHospitalCityNames> GetSingleHospitalsCitiesAsync(int id);
        Task<AddHospitalCityNames> DeleteHospitalsCitiesAsync(int id);
        Task<AddHospitalCityNames> UpdateHospitalsCitiesAsync(int id, AddHospitalCityNames addHospitalCityNames);
    }
}
