using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class ReplyToPatientsRequestDTO
    {
        public string ReplyMessage { get; set; }

        public string VideoCode { get; set; }

        public DateTime Timing { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
