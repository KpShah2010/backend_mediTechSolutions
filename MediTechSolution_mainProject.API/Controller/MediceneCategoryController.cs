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
    public class MediceneCategoryController : ControllerBase
    {
        private readonly IMediceneCategory mediceneCategory;
        private readonly IMapper mapper;

        public MediceneCategoryController(IMediceneCategory mediceneCategory, IMapper mapper)
        {
            this.mediceneCategory = mediceneCategory;
            this.mapper = mapper;
        }

        [HttpPost, Route("createCat")]
        public async Task<IActionResult> Create([FromForm] AddMediceneCategoryRequestDTO addMediceneCategoryRequestDTO)
        {
            var medCatDomain = mapper.Map<MediceneCategory>(addMediceneCategoryRequestDTO);

            await mediceneCategory.CreateMediceneCategoryAsync(medCatDomain);

            mapper.Map<AddMediceneCategoryRequestDTO>(medCatDomain);

            return Ok(new { message = "Medical Category Created successfully" });
        }


        [HttpGet]
        public async Task<IActionResult> getAll() 
        {
            var fetchedCat = await mediceneCategory.GetMediceneCategoryAsync();

            return Ok(new { message = "fetched" , fetchedCat });
        }


        [HttpGet, Route("getById")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var medCatById = await mediceneCategory.GetMediceneCategoryByIdAsync(id);

            if (medCatById == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            return Ok(new { message = "Found Id", medCatById });
        }


        [HttpDelete, Route("delete")]
        public async Task<IActionResult> DeleteByIdCategory(int id)
        {
            var delCatById = await mediceneCategory.DeleteMediceneCategoryAsync(id);

            if (delCatById == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            return Ok(new { message = "Found Id", delCatById });
        }
    }
}
