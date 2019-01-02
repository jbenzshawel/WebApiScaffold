using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiScaffold.Core.Services.Security;
using WebApiScaffold.Core.Models.DTO.Security;

namespace WebApiScaffold.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationDTO dto)
        {
            var user = _userService.Authenticate(dto);

            if (string.IsNullOrEmpty(user.Token))
            {
                return BadRequest(new { errors = "Invalid userName or password" });
            }

            return Ok(user);
        }

        [HttpGet("testauth")]
        public IActionResult TestAuth()
        {
            return Ok(new { message = "Authenticated!" });
        }
    }
}
