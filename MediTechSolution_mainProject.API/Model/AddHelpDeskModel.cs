using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddHelpDeskModel
    {
        public int Id { get; set; }
        public Guid ticketId { get; set; }
        public string issues { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Doctor")]
        public int doctId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
