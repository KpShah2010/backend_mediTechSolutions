using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IMedicalSpeciality
    {
        Task<MedicalDoctorSpeciality> CreateMedicalSpecialityAsync(MedicalDoctorSpeciality medicalSpeciality);
        Task<List<MedicalDoctorSpeciality>> GetAllMedicalSpecialityAsync();
    }
}