using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddHospitalCityNames
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required please fill it!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "image is required please fill it!")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
