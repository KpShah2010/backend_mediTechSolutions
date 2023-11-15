using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using MediTechSolution_mainProject.API.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctor doctor;
        private readonly IMapper mapper;

        public DoctorsController(IDoctor doctor, IMapper mapper)
        {
            this.doctor = doctor;
            this.mapper = mapper;
        }


        [HttpPost, Route("doctorRegister")]
        public async Task<IActionResult> Create([FromForm] AddDoctorRegisterDTO addDoctorRegisterDTO)
        {
            try
            {
                var doctorDomain = mapper.Map<Doctor>(addDoctorRegisterDTO);

                if (addDoctorRegisterDTO.DoctorImage != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addDoctorRegisterDTO.DoctorImage.FileName}";
                    var routePath = "wwwroot/DoctorsImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addDoctorRegisterDTO.DoctorImage.CopyToAsync(stream);
                    }
                    doctorDomain.DoctorImage = fileName;
                }

                await doctor.CreateDoctorAsync(doctorDomain);

                var doctorDTO = mapper.Map<AddDoctorRegisterDTO>(doctorDomain);

                return StatusCode(400, "success register");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var doctors = await doctor.GetAllDoctorAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("doctorById")]
        public async Task<IActionResult> getAll(int id)
        {
            try
            {
                var doctorById = await doctor.GetDoctorByIdAsync(id);

                if (doctorById == null)
                { 
                    return NotFound(new { message = "Id Not Found" });
                }
                return Ok(doctorById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("accept/{id}")]
        public async Task<IActionResult> UpdateIsAccepted(int id)   
        {
            await doctor.UpdateDoctorAsync(id, true);
            return Ok(new { message = "Doctor Accepted" });
        }
    }
}