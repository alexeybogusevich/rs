using KNU.RS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KNU.RS.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LogoutController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;

        public LogoutController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}
