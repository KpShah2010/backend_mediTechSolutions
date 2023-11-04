using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class MedicalDoctorSpeciality
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public string SpecialityImage { get; set; }
    }
}