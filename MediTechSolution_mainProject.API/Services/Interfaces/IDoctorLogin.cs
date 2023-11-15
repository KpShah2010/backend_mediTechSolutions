using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IDoctorLogin
    {
        Doctor DoctorLoginAuthenticate(string username, string password, string licenseNumber);
    }
}
