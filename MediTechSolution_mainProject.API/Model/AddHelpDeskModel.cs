using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddHelpDeskModel
    {
        public int Id { get; set; }
        public Guid ticketId { get; set; } = Guid.NewGuid();
        public string Issues { get; set; }

        [ForeignKey("Doctor")]
        public int DocId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
