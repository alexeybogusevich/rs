using KNU.RS.Data.Constants;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Patient)]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IAccountService registrationService;

        public PatientsController(
            IAccountService registrationService, IPatientService patientService)
        {
            this.registrationService = registrationService;
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

            await registrationService.RegisterAsync(registrationModel);
            return Accepted();
        }
    }
}
