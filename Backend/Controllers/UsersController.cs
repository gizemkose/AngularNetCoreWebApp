using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using WebApi.DTO;
using System.Security.Claims;
using System.Linq;

namespace WebApi.Controllers
{
  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController( IUserService userService)
        {
            _userService = userService;

        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.UserName, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("GetSales")]
        public async Task<IActionResult> GetSales([FromBody] GetSalesDTO getSales)
        {
            var ident = User.Identity as ClaimsIdentity;
            var apiCode = ident.Claims.FirstOrDefault()?.Value;
            
            var salesObj = await _userService.GetSales(getSales, apiCode);        

            return Ok(salesObj);
        }
    }
}
