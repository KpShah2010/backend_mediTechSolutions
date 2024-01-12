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
    public class AddHospitalCityController : ControllerBase
    {
        // constructor

        private readonly IHospitalCity hospitalCityRepository;
        private readonly IMapper mapper;

        public AddHospitalCityController(IHospitalCity hospitalCityRepository, IMapper mapper)
        {
            this.hospitalCityRepository = hospitalCityRepository;
            this.mapper = mapper;
        }

        //==========================================
        // Get all Hospitals Cities names and images
        //==========================================

        [HttpGet]
        public async Task<IActionResult> GetAllHospitlCity()
        {
            try
            {
                var hospitalCity = await hospitalCityRepository.GetAllHospitalsCitiesAsync();
                return Ok(hospitalCity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //=========================================
        // Create Hospitals Cities names and images
        //=========================================

        [HttpPost]
        public async Task<IActionResult> CreateHospitalCity([FromForm] AddHospitalCityRequestDTO addHospitalCityRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var hospitalCityModel = mapper.Map<AddHospitalCityNames>(addHospitalCityRequestDTO);

                if (addHospitalCityRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}{hospitalCityModel.Name}.{addHospitalCityRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/HospitalCityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addHospitalCityRequestDTO.Image.CopyToAsync(stream);
                    }
                    hospitalCityModel.Image = fileName;
                }

                await hospitalCityRepository.CreateHospitalCitiesAsync(hospitalCityModel);

                var HospitalCityDTO = mapper.Map<AddHospitalCityRequestDTO>(hospitalCityModel);

                return Ok(new { message = "added successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //=============================================
        // Get single Hospitals Cities names and images
        //=============================================

        [HttpGet, Route("singleId")]
        public async Task<IActionResult> GetSingleHospitalCities(int id)
        {
            try
            { 
                var hospitalCityId = await hospitalCityRepository.GetSingleHospitalsCitiesAsync(id);
                return Ok(hospitalCityId);
            }
            catch(Exception e) 
            {
                return BadRequest(new { message = e.Message });
            }
        }


        //=========================================
        // Delete Hospitals Cities names and images
        //=========================================

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteHospitalCities(int id)
        {
            try
            {
                var hospitalCityId = await hospitalCityRepository.DeleteHospitalsCitiesAsync(id);
                return Ok(hospitalCityId);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpPut, Route("update/{id}")]
        public async Task<IActionResult> UpdateHospitalCity(int id, [FromForm]EditHospitalsCitiesRequestDTO editHospitalsCitiesRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<AddHospitalCityNames>(editHospitalsCitiesRequestDTO);

                if (editHospitalsCitiesRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{editHospitalsCitiesRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/HospitalCityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editHospitalsCitiesRequestDTO.Image.CopyToAsync(stream);
                    }
                    DomainModel.Image = fileName;
                }

                await hospitalCityRepository.UpdateHospitalsCitiesAsync(id, DomainModel);

                var DomainDTO = mapper.Map<EditHospitalsCitiesRequestDTO>(DomainModel);

                return Ok(DomainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
