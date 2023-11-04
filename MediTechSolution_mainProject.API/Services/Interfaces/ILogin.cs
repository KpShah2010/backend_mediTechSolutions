using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ILogin
    {
        User LoginAuthenticate(string username, string password);
    }
}
