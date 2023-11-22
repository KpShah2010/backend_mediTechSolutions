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
        private readonly IForgotPasswordEmailVerification forgotPasswordEmailVerification;

        public UserController(IUser userRepository, IMapper mapper, ILogin login, 
            IConfiguration configuration, IForgotPasswordEmailVerification forgotPasswordEmailVerification)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.login = login;
            this.configuration = configuration;
            this.forgotPasswordEmailVerification = forgotPasswordEmailVerification;
        }


        // ===========================
        // Get All User from database
        //============================

        [HttpGet, Route("getUsers")]
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

                string emailSubject = "User Registeration Confirmation";
                string name = userDTO.Username;
                string emailMessage = $"Dear {name} \n You are Register Successfully " +
                    $" \n\n Best Regards.\n From Medi.Tech Solutions \n\n Your City is : {userDTO.City}";

                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailSubject, userDTO.Email, name, emailMessage).Wait();


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
        public async Task<IActionResult> Login([FromForm] LoginRequestDTO loginRequestDTO)
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



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var userDeleted = await userRepository.DeleteUserByIdAsync(id);

            if (userDeleted == null)
            {
                return NotFound(new { message = "Id not found" });
            }

            return Ok(userDeleted);
        }



        [HttpPost("ForgotPaswdEmail")]
        public async Task<IActionResult> ForgotEmail([FromForm] ForgotPasswordEmailDTO forgotPasswordEmailDTO)
        {
            try
            {
                var domain = mapper.Map<ForgotPasswordEmail>(forgotPasswordEmailDTO);

                var useremail = await forgotPasswordEmailVerification.ForgotPasswordVerification(domain.Email);

                var resetLink = "http://localhost:3000/resetPasswordForm";

                string emailSubject = "Forgot Password Link";
                string name = "Medi.Tech Solutions";
                string emailMessage = $"Link for forgot password \n\n" +
                    $"Your Forgot Password link is - {resetLink}";


                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailSubject, forgotPasswordEmailDTO.Email, name, emailMessage).Wait();

                if (useremail == null)
                {
                    return BadRequest(new { message = "Please enter registered email address" });
                }

                var dtomail = mapper.Map<ForgotPasswordEmailDTO>(domain);

                return Ok(new { message = "email verify welcome back!", resetLink });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        // password update / reset password
        [HttpPut("resetPassword")]
        public async Task<IActionResult> ResetPasswrd([FromForm] ResetPasswordDTO resetPasswordDTO, [FromForm]ForgotPasswordEmailDTO forgotPasswordEmailDTO)
        {
            try
            {
                var emailCheck = await forgotPasswordEmailVerification.ForgotPasswordVerification(forgotPasswordEmailDTO.Email);

                if (emailCheck != null && emailCheck.Email == forgotPasswordEmailDTO.Email)
                {
                    await forgotPasswordEmailVerification.UpdatePassword(resetPasswordDTO.Password, emailCheck.Email);

                    return Ok(new { message = "password updated" });
                }
                
                return BadRequest(new { message = "please enter registered email address" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "internal server error" });
            }
        }
    
    }
}
