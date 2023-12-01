using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISingleSpecialityDetails
    {
        Task<AddSingleSpecialityDetails> CreateSingleSpecialityDetailsAsync(AddSingleSpecialityDetails addSingleSpecialityDetails);
        Task<AddSingleSpecialityDetails> GetSingleSpecialityDetailsByIdAsync(int id);
        Task<List<AddSingleSpecialityDetails>> GetAllSingleSpecialityDetailsAsync();
    } 
}
