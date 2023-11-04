using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseDetails courseDetails;
        private readonly IMapper mapper;

        public CourseDetailsController(ICourseDetails courseDetails, IMapper mapper)
        {
            this.courseDetails = courseDetails;
            this.mapper = mapper;
        }

        [HttpPost, Route("coursedetails")]
        public async Task<IActionResult> Create([FromForm] AddCourseDetailRequestDTO addCourseDetailRequestDTO)
        {
            try
            {
                var courseModel = mapper.Map<CourseDetailsModel>(addCourseDetailRequestDTO);

                await courseDetails.CreateCourseDetailAsync(courseModel);

                var courseDTO = mapper.Map<AddCourseDetailRequestDTO>(courseModel);

                return Ok(courseDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await courseDetails.GetAllCourseDetails();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
