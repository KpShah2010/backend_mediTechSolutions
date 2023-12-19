namespace MediTechSolution_mainProject.API.DTO
{
    public class EditUserRequestDTO
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}