namespace MediTechSolution_mainProject.API.DTO
{
    public class AddAppointmnetToClientDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeSlotGap { get; set; }
        public Double Price { get; set; }
    }
}
