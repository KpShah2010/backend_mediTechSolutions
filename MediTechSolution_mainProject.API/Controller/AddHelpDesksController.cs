using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AddHelpDesksController : ControllerBase
    {
        private readonly IHelpDesk helpDesk;
        private readonly IMapper mapper;

        public AddHelpDesksController(IHelpDesk helpDesk, IMapper mapper)
        {
            this.helpDesk = helpDesk;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] AddHelpDeskRequestDTO addHelpDeskRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<AddHelpDeskModel>(addHelpDeskRequestDTO);
                await helpDesk.AddHelpDeskModelAsync(DomainModel);
                var DTOModel = mapper.Map<AddHelpDeskRequestDTO>(DomainModel);

                return Ok(DTOModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await helpDesk.GetAllAddHelpDeskModelAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await helpDesk.DeletehelpDeskModelAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
