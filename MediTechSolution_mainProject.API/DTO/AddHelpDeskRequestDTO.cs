using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddHelpDeskRequestDTO
    {
        public Guid ticketId { get; set; }
        public string issues { get; set; }
        public int doctId { get; set; }
    }
}
