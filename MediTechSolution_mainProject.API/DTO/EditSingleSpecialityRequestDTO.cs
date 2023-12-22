namespace MediTechSolution_mainProject.API.DTO
{
    public class EditSingleSpecialityRequestDTO
    {
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int SId { get; set; }
    }
}
