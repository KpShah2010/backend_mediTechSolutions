using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleVideoSpecialityController : ControllerBase
    {
        private readonly ISingleVideoSpeciality singleVideoSpeciality;
        private readonly IMapper mapper;

        public SingleVideoSpecialityController(ISingleVideoSpeciality singleVideoSpeciality, IMapper mapper)
        {
            this.singleVideoSpeciality = singleVideoSpeciality;
            this.mapper = mapper;
        }


        [HttpPost("create")]
        public async Task<IActionResult> create([FromForm] AddSingleVideoSpecialityDTO addSingleVideoSpecialityDTO)
        {
            try
            {
                var domainModel = mapper.Map<SingleSpecialityVideo>(addSingleVideoSpecialityDTO);

                await singleVideoSpeciality.CreateSingleVideoSpecialityAsync(domainModel);
                
                var domainDTO = mapper.Map<AddSingleVideoSpecialityDTO>(domainModel);

                return Ok(domainDTO);
            }
            catch(Exception ex) 
            {
                return BadRequest(new { message = "internal server error" });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await singleVideoSpeciality.GetAllSingleVideoSpecialityAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "internal server error" });
            }
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getingData = await singleVideoSpeciality.GetSingleVideoSpecialityByIdAsync(id);
                return Ok(getingData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "internal server error" });
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await singleVideoSpeciality.DeleteSingleVideoSpecialityByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "internal server error" });
            }
        }
    }
}
