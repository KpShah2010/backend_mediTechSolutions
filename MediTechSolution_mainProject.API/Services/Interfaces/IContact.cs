using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IContact
    {
        Task<ContactModel> CreateContactAsync(ContactModel contactModel);
        Task<List<ContactModel>> GetAllContactFormAsync();
        Task<ContactModel> GetContactFormByIdAsync(int id);
        Task<ContactModel> DeleteContactAsync(int id);
        Task<ContactModel> UpdateContactByIdAsync(int id, ContactModel contactModel);
    }
}