using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepository;
        private readonly IMapper mapper;
        private readonly ILogin login;
        private readonly IConfiguration configuration;

        public UserController(IUser userRepository, IMapper mapper, ILogin login, 
            IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.login = login;
            this.configuration = configuration;
        }


        // ===========================
        // Get All User from database
        //============================

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await userRepository.GetAllUserAsync();
                return Ok(user);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        }


        // ===========================
        // Create User from database
        //============================


        [HttpPost, Route("register")]
        public async Task<IActionResult> CreateUser([FromForm]AddUserRequestDTO addUserRequestDTO)
        {
            try
            {
                var userDomainModel = mapper.Map<User>(addUserRequestDTO);

                if (addUserRequestDTO.ProfileImage != null)
                {
                    var fileName = $"Image-{Guid.NewGuid()}.{addUserRequestDTO.ProfileImage.FileName}";
                    var routePath = "wwwroot/Images";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), routePath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await addUserRequestDTO.ProfileImage.CopyToAsync(stream);
                    }
                    userDomainModel.ProfileImage = fileName;
                }

                var users = await userRepository.CreateUserAsync(userDomainModel);
                var userDTO = mapper.Map<AddUserRequestDTO>(userDomainModel);
                return Ok("successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //===================
        // API for login User
        //===================

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]  LoginRequestDTO loginRequestDTO)
        {
            var userLogin = login.LoginAuthenticate(loginRequestDTO.Username, loginRequestDTO.Password);

            if (userLogin == null)
            {
                return BadRequest(new { message = "Username and password is incorrect" });
            }

            string token = GenerateToken(userLogin);
            return Ok(new { Token = token });
        }

        //=====================
        // Generating JWT Token
        //=====================

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWTToken:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
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
    }
}
