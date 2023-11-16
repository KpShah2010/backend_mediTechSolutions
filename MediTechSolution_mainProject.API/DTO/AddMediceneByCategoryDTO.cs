using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddMediceneByCategoryDTO
    {
        public string MediceneName { get; set; }
        public string MedicenePrescription { get; set; }
        public string MediceneRelated { get; set; }
        public string SideEffect { get; set; }
        public int MediceneCategoryId { get; set; }
    }
}
