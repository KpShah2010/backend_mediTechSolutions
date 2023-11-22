using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IForgotPasswordEmailVerification
    {
       Task<User> ForgotPasswordVerification(string email);
       Task<User> UpdatePassword(string password, string email);
    }
}