using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface ICourseDetails
    {
        Task<CourseDetailsModel> CreateCourseDetailAsync(CourseDetailsModel courseDetailsModel);
        Task<List<CourseDetailsModel>> GetAllCourseDetails();
        Task<CourseDetailsModel> GetCourseDetailsById(int id);
    }
}
