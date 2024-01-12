using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {

        // constructor

        private readonly ISlots slots;
        private readonly IMapper mapper;

        public SlotsController(ISlots slots, IMapper mapper)
        {
            this.slots = slots;
            this.mapper = mapper;
        }


        //======================================
        // Add Slots Using startTime and endTime
        //======================================

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] SlotsRequestDTO slotsRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<Slots>(slotsRequestDTO);

                await slots.CreateSlotsAsync(DomainModel);

                var DomainDTO = mapper.Map<SlotsRequestDTO>(DomainModel);

                return Ok(DomainDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //==============
        // Get All Slots
        //==============

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await slots.GetAllSlotsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //==================
        // Get Slots By Date
        //==================

        [HttpGet("byDate/{*date}")]
        public async Task<IActionResult> GetDataByDate(string date)
        {
            try
            {
                string formattedDate = date.Replace("/", "-");

                DateTime parsedDate = DateTime.ParseExact(formattedDate, "MM-dd-yyyy", null);

                return Ok(await slots.DateWiseSlots(parsedDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
