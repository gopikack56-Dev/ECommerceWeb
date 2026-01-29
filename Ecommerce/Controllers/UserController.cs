using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    
    [Route("[controller]")]
    [ApiController]

   
    public class UserController : Controller
    {

        public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("Data")]
        public IActionResult Index()
        {
            return Ok("Authrized");
        }


        [HttpPost("Register")]
        public async Task<int> Register([FromBody] User user)
        {

            var res = await _userService.Register(user);

            return res;

        }



    }
}
