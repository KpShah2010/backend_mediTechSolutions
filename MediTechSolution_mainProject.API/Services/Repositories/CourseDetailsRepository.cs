using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class CourseDetailsRepository : ICourseDetails
    {
        private readonly ApplicatinDbContext dbContext;

        public CourseDetailsRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CourseDetailsModel> CreateCourseDetailAsync(CourseDetailsModel courseDetailsModel)
        {
            await dbContext.CourseDetails.AddAsync(courseDetailsModel);
            await dbContext.SaveChangesAsync();

            return courseDetailsModel;
        }

        public async Task<List<CourseDetailsModel>> GetAllCourseDetails()
        {
            return await dbContext.CourseDetails.Include(x => x.CollegesModel).ToListAsync();
        }

        public async Task<CourseDetailsModel> GetCourseDetailsById(int id)
        {
            var existingId = await dbContext.CourseDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (existingId == null)
            {
                return null;
            }
            return existingId;
        }
    }
}
