using AutoMapper;
using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyToPatientsController : ControllerBase
    {

        // constructor

        private readonly IReplyToPatients replyToPatients;
        private readonly IMapper mapper;

        public ReplyToPatientsController(IReplyToPatients replyToPatients, IMapper mapper)
        {
            this.replyToPatients = replyToPatients;
            this.mapper = mapper;
        }


        //======================
        // Add Reply to Patients
        //======================

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ReplyToPatientsRequestDTO replyToPatientsRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<ReplyToPatientsModel>(replyToPatientsRequestDTO);

                await replyToPatients.CreateReplyTopatientsAsync(DomainModel);
                var DomainDTO = mapper.Map<ReplyToPatientsRequestDTO>(DomainModel);

                string emailSubject = "Confirmation Mail For Video Conferencing";
                string mail = "19bmiit090@gmail.com";
                string docMail = "kalps6406@gmail.com";
                string name = "Dear";

                string formattedDate = DomainModel.Date.ToString("dd-MM-yyyy");
                string formattedTime = DomainModel.Timing.ToString("HH:mm");

                string emailMessage = $"This is Your Confirmation mail." +
                    $"Thanks for Requesting \n Our Doctor will contact" +
                    $"you very soon." +
                    $" \n\n Best Regards.\n From Medi.Tech Solutions Doctors \n\nYour Confirmation Information is this given Below \n" +
                    $"Date :- {formattedDate} \n" +
                    $"Time :- {formattedTime} \n" +
                    $"Video Code :- {DomainModel.VideoCode} \n";

                string DoctoremailMessage = $"This is Your Confirmation mail." +
                    $"Date :- {formattedDate} \n" +
                    $"Time :- {formattedTime} \n" +
                    $"Video Code :- {DomainModel.VideoCode} \n";

                EmailSender emailSender = new EmailSender();
                EmailSenderDoctor emailSenderDoctor = new EmailSenderDoctor();

                emailSender.SendEmail(emailSubject, mail, name, emailMessage).Wait();

                emailSenderDoctor.SendEmail(emailSubject, docMail, name, DoctoremailMessage).Wait();

                return Ok(DomainDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //==============================
        // Get All Reply to the Patients
        //==============================

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await replyToPatients.GetAllReplyTopatientsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
