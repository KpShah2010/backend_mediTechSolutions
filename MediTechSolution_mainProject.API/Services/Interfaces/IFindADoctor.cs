using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IFindADoctor
    {
        Task<FindADoctor> CreateAsync(FindADoctor findADoctor);
        Task<List<FindADoctor>> GetAllAsync();
        Task<FindADoctor> GetByIdAsync(int id);
    }
}
