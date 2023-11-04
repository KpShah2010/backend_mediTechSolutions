using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class LoginRepository : ILogin
    {
        private readonly ApplicatinDbContext applicatinDbContext;

        public LoginRepository(ApplicatinDbContext applicatinDbContext)
        {
            this.applicatinDbContext = applicatinDbContext;
        }

        public User LoginAuthenticate(string username, string password)
        {
            var user = applicatinDbContext.Users.SingleOrDefault(
                    u => u.Username == username && u.Password == password
                );
            return user;
        }
    }
}
