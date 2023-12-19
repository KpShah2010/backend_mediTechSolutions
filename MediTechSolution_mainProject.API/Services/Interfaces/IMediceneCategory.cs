using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IMediceneCategory
    {
        Task<MediceneCategory> CreateMediceneCategoryAsync(MediceneCategory mediceneCategory);
        Task<List<MediceneCategory>> GetMediceneCategoryAsync();
        Task<MediceneCategory> GetMediceneCategoryByIdAsync(int id);
        Task<MediceneCategory> DeleteMediceneCategoryAsync(int id);
        Task<MediceneCategory> UpdateMediceneCategoryAsync(int id, MediceneCategory mediceneCategory);
    }
}
