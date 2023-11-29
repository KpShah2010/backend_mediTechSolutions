namespace MediTechSolution_mainProject.API.Model
{
    public class AddHospitalsLocations
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationLink { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}