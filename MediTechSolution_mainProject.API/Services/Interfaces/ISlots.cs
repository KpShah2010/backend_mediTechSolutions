using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ISlots
    {
        Task<Slots> CreateSlotsAsync(Slots slots);
        Task<List<Slots>> GetAllSlotsAsync();
        Task<Slots> GetSlotsByIdAsync(int id);
        Task<List<Slots>> DateWiseSlots(DateTime date);
    }
}
