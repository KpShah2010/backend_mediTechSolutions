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
    public class AddSingleSpecialityController : ControllerBase
    {
        //constructor

        private readonly ISingleSpecialityDetails singleSpecialityDetails;
        private readonly IMapper mapper;

        public AddSingleSpecialityController(ISingleSpecialityDetails singleSpecialityDetails, IMapper mapper)
        {
            this.singleSpecialityDetails = singleSpecialityDetails;
            this.mapper = mapper;
        }


        //=================================
        // Adding single speciality details
        //=================================

        [HttpPost("create")]
        public async Task<IActionResult> create([FromForm] AddSingleSpecialityDTO addSingleSpecialityDTO)
        {
            try
            {
                var domainModel = mapper.Map<AddSingleSpecialityDetails>(addSingleSpecialityDTO);

                if (addSingleSpecialityDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addSingleSpecialityDTO.Image.FileName}";
                    var routePath = "wwwroot/MedicalSpecialityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addSingleSpecialityDTO.Image.CopyToAsync(stream);
                    }
                    domainModel.Image = fileName;
                }

                await singleSpecialityDetails.CreateSingleSpecialityDetailsAsync(domainModel);
                var domainDTO = mapper.Map<AddSingleSpecialityDTO>(domainModel);

                return Ok(domainModel);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "internal server error",e });
            }
        }



        //====================================
        // Get By Id single speciality details
        //====================================

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var exitId = await singleSpecialityDetails.GetSingleSpecialityDetailsByIdAsync(id);

                if (exitId == null)
                {
                    return NotFound(new { message = "Id Not Found" });
                }

                return Ok(exitId);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }


        //==================================
        // Get All single speciality details
        //==================================

        [HttpGet]
        public async Task<IActionResult> GetAllDetails ()
        {
            try
            {
                var AllData = await singleSpecialityDetails.GetAllSingleSpecialityDetailsAsync();

                return Ok(AllData);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }


        //=================================
        // Delete single speciality details
        //=================================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var del = await singleSpecialityDetails.DeleteSingleSpecialityDetailsAsync(id);
                return Ok(del);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //=================================
        // Update single speciality details
        //=================================

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] EditSingleSpecialityRequestDTO editSingleSpecialityRequestDTO)
        {
            try
            {
                var domainModel = mapper.Map<AddSingleSpecialityDetails>(editSingleSpecialityRequestDTO);

                if (editSingleSpecialityRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{editSingleSpecialityRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/MedicalSpecialityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editSingleSpecialityRequestDTO.Image.CopyToAsync(stream);
                    }
                    domainModel.Image = fileName;
                }

                await singleSpecialityDetails.UpdateSingleSpecialityDetailsAsync(id, domainModel);

                var domainDTO = mapper.Map<EditSingleSpecialityRequestDTO>(domainModel);

                return Ok(domainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
