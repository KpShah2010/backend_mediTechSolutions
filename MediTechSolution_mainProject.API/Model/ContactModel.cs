using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.Model
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
    }
}