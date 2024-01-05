using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using MediTechSolution_mainProject.API.Services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeUniversityController : ControllerBase
    {
        private readonly ICollegesUniversity collegesUniversity;
        private readonly IMapper mapper;

        public CollegeUniversityController(ICollegesUniversity collegesUniversity, IMapper mapper)
        {
            this.collegesUniversity = collegesUniversity;
            this.mapper = mapper;
        }

        [HttpPost, Route("collegeUniversity")]
        public async Task<IActionResult> Create([FromForm]AddCollegesUniversityRequestDTO addCollegesUniversityRequestDTO)
        {
            try
            {
                var collegesDomainModel = mapper.Map<CollegesModel>(addCollegesUniversityRequestDTO);

                if (addCollegesUniversityRequestDTO.CollegeImage != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addCollegesUniversityRequestDTO.CollegeImage.FileName}";
                    var routePath = "wwwroot/CollegesUniversityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addCollegesUniversityRequestDTO.CollegeImage.CopyToAsync(stream);
                    }
                    collegesDomainModel.CollegeImage = fileName;
                }

                var users = await collegesUniversity.CreateCollegesUniversityAsync(collegesDomainModel);
                var userDTO = mapper.Map<AddCollegesUniversityRequestDTO>(collegesDomainModel);
                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            try
            {
                var collegesUniversities = await collegesUniversity.GetAllCollegesUniversities();

                return Ok(collegesUniversities);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
