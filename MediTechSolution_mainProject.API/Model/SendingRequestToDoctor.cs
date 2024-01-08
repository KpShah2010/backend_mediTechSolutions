using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class SendingRequestToDoctor
    {
        [Key]
        public int Id { get; set; }
        public Guid RequestId { get; set; } = Guid.NewGuid();
        public string Message { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public bool IsAccepted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Doctor Doctor { get; set; }

    }
}
