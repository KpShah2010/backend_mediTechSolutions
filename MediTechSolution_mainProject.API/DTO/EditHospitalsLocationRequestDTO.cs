namespace MediTechSolution_mainProject.API.DTO
{
    public class EditHospitalsLocationRequestDTO
    {
        public string LocationName { get; set; }
        public string LocationLink { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Image { get; set; }
    }
}
