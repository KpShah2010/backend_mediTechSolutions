namespace MediTechSolution_mainProject.API.DTO
{
    public class AddNewsDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
