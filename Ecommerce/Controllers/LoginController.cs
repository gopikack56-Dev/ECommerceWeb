using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        public readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpGet("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Login user)
        {
            var token= await _loginService.Authenticate(user.email,user.password);
            return Ok(token);
        }





    }
}
