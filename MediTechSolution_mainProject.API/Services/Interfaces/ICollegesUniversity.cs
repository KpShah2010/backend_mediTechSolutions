using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ICollegesUniversity
    {
        Task<CollegesModel> CreateCollegesUniversityAsync(CollegesModel collegesModel);
        Task<List<CollegesModel>> GetAllCollegesUniversities();
        Task<CollegesModel> GetCollegesUniversitiesById(int id);
    }
}
