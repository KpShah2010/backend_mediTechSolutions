using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IMediceneByCategory
    {
        Task<MediceneByCategory> CreateMediceneByCategoryAsync(MediceneByCategory mediceneByCategory);
        Task<List<MediceneByCategory>> GetAllMediceneByCategoryAsync();
        Task<MediceneByCategory> GetMediceneByCategoryByIdAsync(int id);
        Task<MediceneByCategory> DeleteMediceneByCategoryAsync(int id);
        Task<MediceneByCategory> UpdateMediceneCategoryAsync(int id, MediceneByCategory mediceneByCategory);
    }
}
