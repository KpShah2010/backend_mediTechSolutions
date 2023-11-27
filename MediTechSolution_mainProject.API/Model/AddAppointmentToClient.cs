using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddAppointmentToClient
    {
        [Key]
        public required int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeSlotGap { get; set; }
        public Double Price { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID{ get; set; }
        public Doctor Doctor { get; set; }
    }
}