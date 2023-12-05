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
    public class NewsController : ControllerBase
    {
        private readonly INews news;
        private readonly IMapper mapper;

        public NewsController(INews news, IMapper mapper)
        {
            this.news = news;
            this.mapper = mapper;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] AddNewsDTO addNewsDTO)
        {
            try
            {
                var domainModel = mapper.Map<News>(addNewsDTO);

                if (addNewsDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addNewsDTO.Image.FileName}";
                    var routePath = "wwwroot/News";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addNewsDTO.Image.CopyToAsync(stream);
                    }
                    domainModel.Image = fileName;
                }

                await news.CreateNewsAsync(domainModel);

                var domainDTO = mapper.Map<AddNewsDTO>(domainModel);

                return Ok(domainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await news.GetAllNewsAsync());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e });
            }
        }
    }
}
