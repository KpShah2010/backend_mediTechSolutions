﻿using AutoMapper;
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

        // constructor

        private readonly IMediceneCategory mediceneCategory;
        private readonly IMapper mapper;

        public MediceneCategoryController(IMediceneCategory mediceneCategory, IMapper mapper)
        {
            this.mediceneCategory = mediceneCategory;
            this.mapper = mapper;
        }


        //====================================
        // Add Medicene Category For Medicenes
        //====================================

        [HttpPost, Route("createCat")]
        public async Task<IActionResult> Create([FromForm] AddMediceneCategoryRequestDTO addMediceneCategoryRequestDTO)
        {
            try
            {
                var medCatDomain = mapper.Map<MediceneCategory>(addMediceneCategoryRequestDTO);

                await mediceneCategory.CreateMediceneCategoryAsync(medCatDomain);

                mapper.Map<AddMediceneCategoryRequestDTO>(medCatDomain);

                return Ok(new { message = "Medical Category Created successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //========================================
        // Get All Medicene Category For Medicenes
        //========================================

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var fetchedCat = await mediceneCategory.GetMediceneCategoryAsync();

                return Ok(new { message = "fetched", fetchedCat });
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }


        //==========================================
        // Get By ID Medicene Category For Medicenes
        //==========================================

        [HttpGet, Route("getById")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            try
            {
                var medCatById = await mediceneCategory.GetMediceneCategoryByIdAsync(id);

                if (medCatById == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                return Ok(new { message = "Found Id", medCatById });
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }


        //=======================================
        // Delete Medicene Category For Medicenes
        //=======================================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteByIdCategory(int id)
        {
            try
            {
                var delCatById = await mediceneCategory.DeleteMediceneCategoryAsync(id);

                if (delCatById == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                return Ok(new { message = "Found Id", delCatById });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //=======================================
        // Update Medicene Category For Medicenes
        //=======================================

        [HttpPut("update/{id}")]    
        public async Task<IActionResult> update(int id, [FromForm] EditMediceneCategoryRequestDTO editMediceneCategoryRequestDTO)
        {
            try 
            {
                var domainModel = mapper.Map<MediceneCategory>(editMediceneCategoryRequestDTO);
                await mediceneCategory.UpdateMediceneCategoryAsync(id, domainModel);
                var DTOmodel = mapper.Map<EditMediceneCategoryRequestDTO>(domainModel);

                return Ok(DTOmodel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}