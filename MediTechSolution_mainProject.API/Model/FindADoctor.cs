using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class FindADoctor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MedicalDoctorSpeciality")]
        public int SpecialityDoctorId { get; set; }
        public MedicalDoctorSpeciality MedicalDoctorSpeciality { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
