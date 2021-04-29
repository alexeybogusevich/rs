using KNU.RS.Data.Constants;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Doctor)]
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
            if (!Guid.TryParse(
                HttpContext.User.FindFirstValue(ClaimTypes.Name),
                out var userId))
            {
                return BadRequest("Користувача не знайдено.");
            }

            var patients = await patientService.GetInfoByDoctorAsync(userId);
            return Ok(patients);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAsync([FromBody] PatientRegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(v => v.Errors));
            }

            await registrationService.RegisterAsync(registrationModel);
            return Accepted();
        }
    }
}
