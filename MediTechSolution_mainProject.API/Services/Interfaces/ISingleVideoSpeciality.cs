using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISingleVideoSpeciality
    {
        Task<SingleSpecialityVideo> CreateSingleVideoSpecialityAsync(SingleSpecialityVideo singleSpecialityVideo);
        Task<List<SingleSpecialityVideo>> GetAllSingleVideoSpecialityAsync();
        Task<SingleSpecialityVideo> GetSingleVideoSpecialityByIdAsync(int id);
        Task<SingleSpecialityVideo> DeleteSingleVideoSpecialityByIdAsync(int id);
    }
}