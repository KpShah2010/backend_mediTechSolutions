using MediTechSolution_mainProject.API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddFindADoctorRequestDTO
    {
        public int SpecialityDoctorId { get; set; }
        public int DoctorId { get; set; }
    }
}
