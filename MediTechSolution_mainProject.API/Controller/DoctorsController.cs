﻿using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using MediTechSolution_mainProject.API.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        // constructor

        private readonly IDoctor doctor;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IDoctorLogin doctorLogin;
        private readonly IAppointmentToClient appointmentToClient;

        public DoctorsController(IDoctor doctor, IMapper mapper, 
            IConfiguration configuration, IDoctorLogin doctorLogin, IAppointmentToClient appointmentToClient)
        {
            this.doctor = doctor;
            this.mapper = mapper;
            this.configuration = configuration;
            this.doctorLogin = doctorLogin;
            this.appointmentToClient = appointmentToClient;
        }


        //========================
        // Doctor's Registerations
        //========================

        [HttpPost, Route("doctorRegister")]
        public async Task<IActionResult> Create([FromForm] AddDoctorRegisterDTO addDoctorRegisterDTO)
        {
            try
            {
                var doctorDomain = mapper.Map<Doctor>(addDoctorRegisterDTO);

                if (addDoctorRegisterDTO.DoctorImage != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addDoctorRegisterDTO.DoctorImage.FileName}";
                    var routePath = "wwwroot/DoctorsImages";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addDoctorRegisterDTO.DoctorImage.CopyToAsync(stream);
                    }
                    doctorDomain.DoctorImage = fileName;
                }

                await doctor.CreateDoctorAsync(doctorDomain);

                var doctorDTO = mapper.Map<AddDoctorRegisterDTO>(doctorDomain);

                return StatusCode(400, "success register");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //===============
        // Doctor's Lists
        //===============

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var doctors = await doctor.GetAllDoctorAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //=======================
        // Doctors Listsing By ID
        //=======================

        [HttpGet, Route("doctorById")]
        public async Task<IActionResult> getAll(int id)
        {
            try
            {
                var doctorById = await doctor.GetDoctorByIdAsync(id);

                if (doctorById == null)
                { 
                    return NotFound(new { message = "Id Not Found" });
                }
                return Ok(doctorById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //=========================================
        // Admin Accepted Doctors Request for Login
        //=========================================


        [HttpPut("accept/{id}")]
        public async Task<IActionResult> UpdateIsAccepted(int id)   
        {
            try
            {
                await doctor.UpdateDoctorAsync(id, true);
                return Ok(new { message = "Doctor Accepted" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //===============
        // Doctor's Login
        //===============


        [HttpPost, Route("login")]
        public async Task<IActionResult> DoctorLogin([FromForm] DoctorLoginRequestDTO doctorLoginRequestDTO)
        {
            try
            {
                var doctorsLogin = doctorLogin.DoctorLoginAuthenticate(doctorLoginRequestDTO.Username,
                doctorLoginRequestDTO.Password,
                doctorLoginRequestDTO.LicenseNumber);

                if (doctorsLogin == null)
                {
                    return BadRequest(new { message = "Username and password is incorrect" });
                }

                var doctorsFromDB = await doctor.GetDoctorByIdAsync(doctorsLogin.Id);

                if (doctorsFromDB == null)
                {
                    return BadRequest(new { message = "Doctor not found" });
                }

                if (!doctorsFromDB.isAccepted == true)
                {
                    return BadRequest(new { message = "Not Accepted from admin side" });
                }

                string token = GenerateToken(doctorsLogin);

                return Ok(new { Token = token, doctorDetail = JsonConvert.SerializeObject(doctorsFromDB) });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //=====================
        // Generating JWT Token
        //=====================

        private string GenerateToken(Doctor doctor)
        {   
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWTToken:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, doctor.Username),
                new Claim("DoctorDetails", JsonConvert.SerializeObject(doctor)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["JWTToken:Issuer"],
                audience: configuration["JWTToken:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }



        //====================
        // Delete Doctor By Id
        //====================

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await doctor.DeleteDoctorAsync(id);
                return Ok(new { message = "deleted" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}