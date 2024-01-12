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
    public class SendingRequestToDoctorController : ControllerBase
    {

        // constructor

        private readonly ISendingRequestToDoctor sendingRequestToDoctor;
        private readonly IMapper mapper;

        public SendingRequestToDoctorController(ISendingRequestToDoctor sendingRequestToDoctor, IMapper mapper)
        {
            this.sendingRequestToDoctor = sendingRequestToDoctor;
            this.mapper = mapper;
        }


        //========================
        // Add Sending to Patients
        //========================

        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest([FromForm] SendingRequestToDoctorDTO sendingRequestToDoctorDTO)
        {
            try
            {
                var DomainModel = mapper.Map<SendingRequestToDoctor>(sendingRequestToDoctorDTO);
                await sendingRequestToDoctor.SendToDoctorAsync(DomainModel);
                var DomainDTO = mapper.Map<SendingRequestToDoctorDTO>(DomainModel);

                return Ok(DomainDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //============================
        // Get All Sending to Patients
        //============================

        [HttpGet("get")]
        public async Task<IActionResult> GetAllRequest()
        {
            try
            {
                return Ok(await sendingRequestToDoctor.GetAllSendToDoctorAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
