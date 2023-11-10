using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class ContactRepository : IContact
    {
        private readonly ApplicatinDbContext dbContext;

        public ContactRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ContactModel> CreateContactAsync(ContactModel contactModel)
        {
            await dbContext.Contacts.AddAsync(contactModel);
            await dbContext.SaveChangesAsync();

            return contactModel;
        }

        public async Task<List<ContactModel>> GetAllContactFormAsync()
        {
            return await dbContext.Contacts.ToListAsync();
        }
    }
}
