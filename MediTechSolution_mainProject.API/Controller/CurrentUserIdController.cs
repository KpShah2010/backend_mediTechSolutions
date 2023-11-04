using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediTechSolution_mainProject.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrentUserIdController : ControllerBase
    {
        [HttpGet("user-id")]
        public IActionResult GetUserId()
        {
            bool authenticatedUser = User.Identity.IsAuthenticated;

            string color = authenticatedUser ? "Green" : "Red";
            return Ok(new { Color = color });
        }
    }
}
