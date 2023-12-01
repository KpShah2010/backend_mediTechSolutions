using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class SingleSpecialityVideo
    {
        public int Id { get; set; }
        public string VideoLink { get; set; }

        [ForeignKey("MedicalDoctorSpeciality")]
        public int SVId { get; set; }

        public MedicalDoctorSpeciality MedicalDoctorSpeciality { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
