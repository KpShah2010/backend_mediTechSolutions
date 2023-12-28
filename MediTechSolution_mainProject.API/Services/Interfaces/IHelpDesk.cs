using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IHelpDesk
    {
        Task<AddHelpDeskModel> AddHelpDeskModelAsync(AddHelpDeskModel addHelpDeskModel);
        Task<List<AddHelpDeskModel>> GetAllAddHelpDeskModelAsync();
        Task<AddHelpDeskModel> DeletehelpDeskModelAsync(int id);
        Task<AddHelpDeskModel> UpdateHelpDesksModelAsync(int id, AddHelpDeskModel addHelpDeskModel);
    }
}
