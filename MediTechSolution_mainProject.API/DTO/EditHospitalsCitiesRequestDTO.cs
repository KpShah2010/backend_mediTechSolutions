using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.DTO
{
    public class EditHospitalsCitiesRequestDTO
    {
        [Required(ErrorMessage = "name is required please fill it!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "image is required please fill it!")]
        public IFormFile Image { get; set; }
    }
}
