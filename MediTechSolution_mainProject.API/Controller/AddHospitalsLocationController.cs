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
    public class AddHospitalsLocationController : ControllerBase
    {
        //constructor
        private readonly IHospitalsLocations hospitalsLocations;
        private readonly IMapper mapper;

        public AddHospitalsLocationController(IHospitalsLocations hospitalsLocations, IMapper mapper)
        {
            this.hospitalsLocations = hospitalsLocations;
            this.mapper = mapper;
        }


        //============================
        // Adding Hospitals Locations
        //============================

        [HttpPost("createLocations")]
        public async Task<IActionResult> Create([FromForm] AddHospitalLocationRequestDTO addHospitalLocationRequestDTO)
        {
            try
            {
                var domainModel = mapper.Map<AddHospitalsLocations>(addHospitalLocationRequestDTO);

                if (addHospitalLocationRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addHospitalLocationRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/HospitalCityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addHospitalLocationRequestDTO.Image.CopyToAsync(stream);
                    }
                    domainModel.Image = fileName;
                }

                await hospitalsLocations.CreateHospitalsLocationAsync(domainModel);

                var DomainDTO = mapper.Map<AddHospitalLocationRequestDTO>(domainModel);
                return Ok(DomainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }


        //============================
        // Get All Hospitals Locations
        //============================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var hospitalLocat = await hospitalsLocations.GetAllHospitalsLocationAsync();
                return Ok(hospitalLocat);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }


        //==============================
        // Deleting Hospitals Locations
        //==============================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var delId = await hospitalsLocations.DeleteHospitalsLocationAsync(id);
                if (delId == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                return Ok(new { message = "Data deleted" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }


        //=================================
        // Update by id Hospitals Locations
        //=================================

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateLocations(int id, [FromForm]EditHospitalsLocationRequestDTO editHospitalsLocationRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<AddHospitalsLocations>(editHospitalsLocationRequestDTO);

                if (editHospitalsLocationRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{editHospitalsLocationRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/HospitalCityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editHospitalsLocationRequestDTO.Image.CopyToAsync(stream);
                    }
                    DomainModel.Image = fileName;
                }

                await hospitalsLocations.UpdateHospitalsLocationAsync(id, DomainModel);

                var DomainDTO = mapper.Map<EditHospitalsLocationRequestDTO>(DomainModel);

                return Ok(DomainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}