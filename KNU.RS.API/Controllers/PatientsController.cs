using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] 
    public class PatientsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IPatientService patientService;

        public PatientsController(
            IAccountService accountService, IPatientService patientService)
        {
            this.accountService = accountService;
            this.patientService = patientService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PatientInfo>), 200)]
        public async Task<ActionResult<IEnumerable<PatientInfo>>> GetAsync()
        {
            var patients = await patientService.GetInfoAsync();
            return Ok(patients);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAsync([FromBody] PatientRegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await accountService.RegisterAsync(registrationModel);
            return Accepted();
        }
    }
}
