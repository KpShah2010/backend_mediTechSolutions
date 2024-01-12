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
    public class AppointmentToClientController : ControllerBase
    {

        // constructor

        private readonly IAppointmentToClient appointmentToClient;
        private readonly IMapper mapper;

        public AppointmentToClientController(IAppointmentToClient appointmentToClient, IMapper mapper)
        {
            this.appointmentToClient = appointmentToClient;
            this.mapper = mapper;
        }


        //==============================
        // Adding Appointment to ptients
        //==============================

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Create([FromForm] AddAppointmnetToClientDTO addAppointmnetToClientDTO)
        {
            var appointmentModel = mapper.Map<AddAppointmentToClient>(addAppointmnetToClientDTO);

            await appointmentToClient.CreateaddAppointmentToClientAsync(appointmentModel);

            var appointmentDTO = mapper.Map<AddAppointmnetToClientDTO>(appointmentModel);
            return Ok(new { message = "Record Added Successfully", appointmentDTO });
        }


        //===============================
        // Get All Appointment to ptients
        //===============================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allData = await appointmentToClient.GetAllAppointmentToClientAsync();
                return Ok(allData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //====================================
        // Geting By ID Appointment to ptients
        //====================================


        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var exisId = await appointmentToClient.GetAppointmentToClientByIdAsync(id);

                if (exisId == null)
                {
                    return NotFound(new { message = "Id not found" });
                }

                return Ok(exisId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
