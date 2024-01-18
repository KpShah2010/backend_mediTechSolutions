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

        // constructor

        private readonly INews news;
        private readonly IMapper mapper;

        public NewsController(INews news, IMapper mapper)
        {
            this.news = news;
            this.mapper = mapper;
        }


        //=========
        // Add News
        //=========

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



        //=============
        // Get All News
        //=============

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


        //==================
        // Delete By ID News
        //==================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            try
            {
                return Ok(await news.DeleteNewsAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //==================
        // Update By ID News
        //==================

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromForm] EditNewsRequestDTO editNewsRequestDTO)
        {
            try
            {
                var DomainModel = mapper.Map<News>(editNewsRequestDTO);

                if (editNewsRequestDTO.Image != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{editNewsRequestDTO.Image.FileName}";
                    var routePath = "wwwroot/News";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editNewsRequestDTO.Image.CopyToAsync(stream);
                    }
                    DomainModel.Image = fileName;
                }

                await news.UpdateNewsAsync(id, DomainModel);

                var DomainDTO = mapper.Map<EditNewsRequestDTO>(DomainModel);
                return Ok(DomainDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        //===============
        // Get By ID News
        //===============

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await news.GetNewsByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
