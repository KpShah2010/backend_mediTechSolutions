namespace MediTechSolution_mainProject.API.DTO
{
    public class EditMediceneByCategoryRequestDTO
    {
        public string MediceneName { get; set; }
        public string MedicenePrescription { get; set; }
        public string MediceneRelated { get; set; }
        public string SideEffect { get; set; }
        public int MediceneCategoryId { get; set; }
    }
}