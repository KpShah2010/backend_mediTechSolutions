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
        private readonly IMediceneByCategory mediceneByCategory;
        private readonly IMapper mapper;

        public MediceneByCategoryController(IMediceneByCategory mediceneByCategory, IMapper mapper)
        {
            this.mediceneByCategory = mediceneByCategory;
            this.mapper = mapper;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromForm] AddMediceneByCategoryDTO addMediceneByCategoryDTO)
        {
            var mediceneByCatDomain = mapper.Map<MediceneByCategory>(addMediceneByCategoryDTO);
            await mediceneByCategory.CreateMediceneByCategoryAsync(mediceneByCatDomain);
            mapper.Map<AddMediceneByCategoryDTO>(mediceneByCatDomain);

            return Ok(new { message = "Successfully created" });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mediceneByCatId = await mediceneByCategory.GetAllMediceneByCategoryAsync();

            return Ok(mediceneByCatId);
        }


        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mediceneById = await mediceneByCategory.GetMediceneByCategoryByIdAsync(id);

            if (mediceneById == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            return Ok(mediceneById);
        }


        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mediceneById = await mediceneByCategory.GetMediceneByCategoryByIdAsync(id);

            if (mediceneById == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            await mediceneByCategory.DeleteMediceneByCategoryAsync(id);

            return Ok(new { message = "record deleted successfully" });
        }


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