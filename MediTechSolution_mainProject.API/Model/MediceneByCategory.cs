using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class MediceneByCategory
    {
        public int Id { get; set; }
        public string MediceneName { get; set; }
        public string MedicenePrescription { get; set; }
        public string MediceneRelated { get; set; }
        public string SideEffect { get; set; }

        [ForeignKey("MediceneCategory")]
        public int MediceneCategoryId { get; set; }

        public MediceneCategory MediceneCategory { get; set; }
    }
}
