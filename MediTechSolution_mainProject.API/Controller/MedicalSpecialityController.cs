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
    public class MedicalSpecialityController : ControllerBase
    {
        private readonly IMedicalSpeciality medicalSpecialRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MedicalSpecialityController(IMedicalSpeciality medicalSpecialRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.medicalSpecialRepository = medicalSpecialRepository;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpPost, Route("postMedicalSpeciality")]
        public async Task<IActionResult> Create([FromForm] AddMedicalSpecialityRequestDTO addMedicalSpecialityRequestDTO)
        {
            try 
            {
                var successMsg = new MessageData
                {
                    MsgCode = "200",
                    Msg = "Sucess!!!"
                };

                var medicalModel = mapper.Map<MedicalDoctorSpeciality>(addMedicalSpecialityRequestDTO);

                if (addMedicalSpecialityRequestDTO.SpecialityImage != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addMedicalSpecialityRequestDTO.SpecialityImage.FileName}";
                    var routePath = "wwwroot/MedicalSpecialityImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addMedicalSpecialityRequestDTO.SpecialityImage.CopyToAsync(stream);
                    }
                    medicalModel.SpecialityImage = fileName;
                }

                await medicalSpecialRepository.CreateMedicalSpecialityAsync(medicalModel);
                mapper.Map<AddMedicalSpecialityRequestDTO>(medicalModel);

                return Ok(successMsg);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var medicalSpeciality = await medicalSpecialRepository.GetAllMedicalSpecialityAsync();
                return Ok(medicalSpeciality);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        // update medical speciality
        [HttpPut("update/{id}")]
        public async Task<IActionResult> update(int id, [FromForm] EditMedicalSpecialityDTO editMedicalSpecialityDTO)
        {
            var specialityDomain = mapper.Map<MedicalDoctorSpeciality>(editMedicalSpecialityDTO);

            if (editMedicalSpecialityDTO.SpecialityImage != null)
            {
                var fileName = $"Image-{Guid.NewGuid()}.{editMedicalSpecialityDTO.SpecialityImage.FileName}";
                var routePath = "wwwroot/MedicalSpecialityImages";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await editMedicalSpecialityDTO.SpecialityImage.CopyToAsync(stream);
                }
                specialityDomain.SpecialityImage = fileName;
            }

            await medicalSpecialRepository.UpdateMedicalSpecialityAsync(id, specialityDomain);

            mapper.Map<EditMedicalSpecialityDTO>(specialityDomain);

            return Ok(new { message = "data updated" });
        }


        // fetch by id
        [HttpGet("ByID/{id}")]
        public async Task<IActionResult> ById(int id)
        {
            var existid = await medicalSpecialRepository.GetMedicalSpecialityByIdAsync(id);
            if (existid == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            return Ok(existid);
        }


        // delete medical speciality
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var MedicalId = await medicalSpecialRepository.GetMedicalSpecialityByIdAsync(id);

            if (MedicalId == null)
            {
                return NotFound();
            }

            await medicalSpecialRepository.DeleteMedicalSpeciality(id);

            return Ok(new { message = "data deleted" });
        }
    }
}
