using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.DTO
{
    public class EditMedicalSpecialityDTO
    {
        [Required(ErrorMessage = "Spceiality name is required please fill it.")]
        public string SpecialityName { get; set; }

        [Required(ErrorMessage = "Spceiality image is required please fill it.")]
        public IFormFile SpecialityImage { get; set; }
    }
}
