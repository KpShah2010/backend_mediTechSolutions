using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IMedicalSpeciality
    {
        Task<MedicalDoctorSpeciality> CreateMedicalSpecialityAsync(MedicalDoctorSpeciality medicalSpeciality);
        Task<List<MedicalDoctorSpeciality>> GetAllMedicalSpecialityAsync();
        Task<MedicalDoctorSpeciality> GetMedicalSpecialityByIdAsync(int id);
        Task<MedicalDoctorSpeciality> UpdateMedicalSpecialityAsync(int id, MedicalDoctorSpeciality medicalDoctorSpeciality);
        Task<MedicalDoctorSpeciality> DeleteMedicalSpeciality(int id);
    }
}