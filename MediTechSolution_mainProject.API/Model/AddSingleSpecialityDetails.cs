using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddSingleSpecialityDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey("MedicalDoctorSpeciality")]
        public int SId { get; set; }

        public MedicalDoctorSpeciality MedicalDoctorSpeciality { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
