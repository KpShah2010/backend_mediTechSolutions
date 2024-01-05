using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class SendingRequestToDoctor
    {
        [Key]
        public int Id { get; set; }
        public Guid RequestId { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public string Message { get; set; }

        public bool isAccepted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }

        public Doctor Doctor { get; set; }
    }
}
