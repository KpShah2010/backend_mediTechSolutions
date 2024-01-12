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
    public class MediceneByCategoryController : ControllerBase
    {

        // costructor

        private readonly IMediceneByCategory mediceneByCategory;
        private readonly IMapper mapper;

        public MediceneByCategoryController(IMediceneByCategory mediceneByCategory, IMapper mapper)
        {
            this.mediceneByCategory = mediceneByCategory;
            this.mapper = mapper;
        }


        //======================
        // Add Medicene Category
        //======================

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromForm] AddMediceneByCategoryDTO addMediceneByCategoryDTO)
        {
            try
            {
                var mediceneByCatDomain = mapper.Map<MediceneByCategory>(addMediceneByCategoryDTO);
                await mediceneByCategory.CreateMediceneByCategoryAsync(mediceneByCatDomain);
                mapper.Map<AddMediceneByCategoryDTO>(mediceneByCatDomain);

                return Ok(new { message = "Successfully created" });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //==========================
        // Get All Medicene Category
        //==========================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var mediceneByCatId = await mediceneByCategory.GetAllMediceneByCategoryAsync();

                return Ok(mediceneByCatId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //============================
        // Get By ID Medicene Category
        //============================

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var mediceneById = await mediceneByCategory.GetMediceneByCategoryByIdAsync(id);

                if (mediceneById == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                return Ok(mediceneById);
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }


        //===============================
        // Delete By ID Medicene Category
        //===============================

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mediceneById = await mediceneByCategory.GetMediceneByCategoryByIdAsync(id);

                if (mediceneById == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                await mediceneByCategory.DeleteMediceneByCategoryAsync(id);

                return Ok(new { message = "record deleted successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //=========================
        // Update Medicene Category
        //=========================

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]EditMediceneByCategoryRequestDTO editMediceneByCategoryRequestDTO)
        {
            try
            {
                var domainModel = mapper.Map<MediceneByCategory>(editMediceneByCategoryRequestDTO);
                await mediceneByCategory.UpdateMediceneCategoryAsync(id, domainModel);
                var DTOModel = mapper.Map<EditMediceneByCategoryRequestDTO>(domainModel);

                return Ok(DTOModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}   