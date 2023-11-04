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
    public class FindADoctorController : ControllerBase
    {
        private readonly IFindADoctor findADoctor;
        private readonly IMapper mapper;

        public FindADoctorController(IFindADoctor findADoctor, IMapper mapper)
        {
            this.findADoctor = findADoctor;
            this.mapper = mapper;
        }

        [HttpPost, Route("findADoctor")]
        public async Task<IActionResult> Create(AddFindADoctorRequestDTO addFindADoctorRequestDTO)
        {
            var findDoctorModel = mapper.Map<FindADoctor>(addFindADoctorRequestDTO);
            await findADoctor.CreateAsync(findDoctorModel);
            var findADoctorDTO = mapper.Map<AddFindADoctorRequestDTO>(findDoctorModel);

            return Ok(new { message = "Created Success!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctorFind = await findADoctor.GetAllAsync();

            return Ok(doctorFind);
        }
    }
}
