using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class ReplyToPatientsModel
    {
        [Key]
        public int Id { get; set; }

        public string ReplyMessage { get; set; }

        public string VideoCode { get; set; }

        public DateTime Timing { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
