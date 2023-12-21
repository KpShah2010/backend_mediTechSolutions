using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISingleSpecialityDetails
    {
        Task<AddSingleSpecialityDetails> CreateSingleSpecialityDetailsAsync(AddSingleSpecialityDetails addSingleSpecialityDetails);
        Task<AddSingleSpecialityDetails> GetSingleSpecialityDetailsByIdAsync(int id);
        Task<List<AddSingleSpecialityDetails>> GetAllSingleSpecialityDetailsAsync();
        Task<AddSingleSpecialityDetails> DeleteSingleSpecialityDetailsAsync(int id);
        Task<AddSingleSpecialityDetails> UpdateSingleSpecialityDetailsAsync(int id, AddSingleSpecialityDetails addSingleSpecialityDetails);
    } 
}
