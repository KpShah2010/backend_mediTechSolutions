﻿using AutoMapper;
using EllipticCurve.Utils;
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
    public class ContactController : ControllerBase
    {

        // constructor

        private readonly IContact contact;
        private readonly IMapper mapper;

        public ContactController(IContact contact, IMapper mapper)
        {
            this.contact = contact;
            this.mapper = mapper;
        }


        //========================
        // Adding Contacts Details
        //========================

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddContactRequestDTO addContactRequestDTO)
        {
            try
            {
                var contactDomain = mapper.Map<ContactModel>(addContactRequestDTO);

                await contact.CreateContactAsync(contactDomain);

                var contactDTO = mapper.Map<AddContactRequestDTO>(contactDomain);

                string emailSubject = "Contact Information";
                string name = contactDTO.Name;
                string emailMessage = $"Dear {name} \n Your Query Recieved us. " +
                    $"Thanks for contacting us \n Our Team will contact " +
                    $"you very soon." +
                    $" \n\n Best Regards.\n From Medi.Tech Solutions \n\n Your Query: \n {contactDTO.Query}";

                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailSubject, contactDTO.Email, name, emailMessage).Wait();

                return Ok(new { message = "successfully inserted", contactDTO });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error! Something went wrong!", e });
            }
        }



        //============================
        // Geting All Contacts Details
        //============================

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


        //========================
        // Delete Contacts Details
        //========================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteContact(int id)
        {
            try
            {
                var deleteContactID = await contact.DeleteContactAsync(id);

                if (deleteContactID == null)
                {
                    return NotFound();
                }

                return Ok(deleteContactID);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
