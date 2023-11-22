using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class ForgotPasswordEmailRepository: IForgotPasswordEmailVerification
    {
        private readonly ApplicatinDbContext dbContext;

        public ForgotPasswordEmailRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> ForgotPasswordVerification(string email)
        {
            var userEmail = await dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if(userEmail == null)
            {
                return null;
            }

            return userEmail;
        }

        public async Task<User> UpdatePassword(string password, string email)
        {
            var emailCheck = await dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (emailCheck == null)
            {
                return null;
            }

            emailCheck.Password = password;
            await dbContext.SaveChangesAsync();

            return emailCheck;
        }
    }
}
