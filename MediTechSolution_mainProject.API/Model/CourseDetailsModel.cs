using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class CourseDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string Eligibility { get; set; }
        public string Durations { get; set; }
        public string EntranceExam { get; set; }
        public string AverageFees { get; set; }
        public string AverageSalary { get; set; }
        public string CarrerOptions { get; set; }

        [ForeignKey("CollegesModel")]
        public int CollegeUniversityId { get; set; }
        public CollegesModel CollegesModel { get; set; }
    }
}
