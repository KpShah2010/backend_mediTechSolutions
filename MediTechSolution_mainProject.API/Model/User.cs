using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}