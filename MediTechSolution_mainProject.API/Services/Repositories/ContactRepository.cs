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

        public async Task<ContactModel> DeleteContactAsync(int id)
        {
            var contactDeleteId = await dbContext.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (contactDeleteId == null)
            {
                return null;
            }

            dbContext.Contacts.Remove(contactDeleteId);
            await dbContext.SaveChangesAsync();

            return contactDeleteId;
        }

        public async Task<List<ContactModel>> GetAllContactFormAsync()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<ContactModel> GetContactFormByIdAsync(int id)
        {
            var contactById = await dbContext.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (contactById == null)
            {
                return null;
            }

            return contactById;
        }

        public async Task<ContactModel> UpdateContactByIdAsync(int id, ContactModel contactModel)
        {
            var contactUpdateId = await dbContext.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (contactUpdateId == null)
            {
                return null;
            }

            contactUpdateId.Name = contactModel.Name;
            contactUpdateId.Email = contactModel.Email;
            contactUpdateId.Query = contactModel.Query;

            await dbContext.SaveChangesAsync();

            return contactUpdateId;
        }
    }
}
