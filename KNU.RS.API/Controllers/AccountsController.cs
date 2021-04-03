using Microsoft.AspNetCore.Mvc;
using KNU.RS.Logic.Services.AccountService;
using System.Threading.Tasks;
using KNU.RS.Logic.Models.Account;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await accountService.LoginAsync(loginModel))
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPost("logout")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> LogoutAsync()
        {
            await accountService.LogoutAsync();
            return Ok();
        }

        [HttpPost("patient")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAsync([FromBody] PatientRegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await accountService.RegisterPatientAsync(registrationModel);
            return Accepted();
        }
    }
}
