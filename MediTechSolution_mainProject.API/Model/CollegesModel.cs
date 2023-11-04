using System.ComponentModel.DataAnnotations;

namespace MediTechSolution_mainProject.API.Model
{
    public class CollegesModel
    {
        [Key]
        public int Id { get; set; }
        public string  CollegesName { get; set; }
        public string CollegesDescriptions { get; set; }
        public string Location { get; set; }
        public string Eligibility { get; set; }
        public string Durations { get; set; }
        public string EntranceExam { get; set; }
        public string AverageFees { get; set; }
        public string AverageSalary { get; set; }
        public string Type { get; set; }
        public string CollegeImage { get; set; }
    }
}
