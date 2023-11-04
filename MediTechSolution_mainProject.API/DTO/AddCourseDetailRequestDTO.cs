namespace MediTechSolution_mainProject.API.DTO
{
    public class AddCourseDetailRequestDTO
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string Eligibility { get; set; }
        public string Durations { get; set; }
        public string EntranceExam { get; set; }
        public string AverageFees { get; set; }
        public string AverageSalary { get; set; }
        public string CarrerOptions { get; set; }
        public int CollegeUniversityId { get; set; }
    }
}
