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
    public class ContactController : ControllerBase
    {
        private readonly IContact contact;
        private readonly IMapper mapper;

        public ContactController(IContact contact, IMapper mapper)
        {
            this.contact = contact;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddContactRequestDTO addContactRequestDTO)
        {
            try
            {
                var contactDomain = mapper.Map<ContactModel>(addContactRequestDTO);

                await contact.CreateContactAsync(contactDomain);

                var contactDTO = mapper.Map<AddContactRequestDTO>(contactDomain);

                return Ok(new { message = "successfully inserted", contactDTO });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error! Something went wrong!", e });
            }
        }


        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var contactDetails = await contact.GetAllContactFormAsync();
                return Ok(contactDetails);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error! Something went wrong in fetching!", e });
            }
        }
    }
}
