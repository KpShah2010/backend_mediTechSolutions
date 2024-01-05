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
        private readonly ISendingRequestToDoctor sendingRequestToDoctor;
        private readonly IMapper mapper;

        public SendingRequestToDoctorController(ISendingRequestToDoctor sendingRequestToDoctor, IMapper mapper)
        {
            this.sendingRequestToDoctor = sendingRequestToDoctor;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] SendingRequestToDoctorDTO sendingRequestToDoctorDTO)
        {
            try
            {
                var DomainMOdel = mapper.Map<SendingRequestToDoctor>(sendingRequestToDoctorDTO);
                await sendingRequestToDoctor.AddSendingRequestToDoctorAsync(DomainMOdel);
                var DomainDTO = mapper.Map<SendingRequestToDoctorDTO>(DomainMOdel);

                return Ok(DomainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await sendingRequestToDoctor.GetALlSendingRequestAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
