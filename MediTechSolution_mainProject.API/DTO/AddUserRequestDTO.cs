using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddUserRequestDTO
    {
        [Required(ErrorMessage = "first name is required please fill it!")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "last name is required please fill it!")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "username is required please fill it!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required please fill it!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required please fill it!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required please fill it!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "State is required please fill it!")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required please fill it!")]
        public string City { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = "profile image is required please fill it!")]
        public IFormFile ProfileImage { get; set; }
    }
}
