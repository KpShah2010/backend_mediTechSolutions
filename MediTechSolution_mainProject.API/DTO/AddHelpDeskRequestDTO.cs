using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddHelpDeskRequestDTO
    {
        public string Issues { get; set; }
        public int DocId { get; set; }
    }
}
