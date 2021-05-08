using KNU.RS.Data.Constants;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Doctor)]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PatientInfo>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<IEnumerable<PatientInfo>>> GetAsync(CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(
                HttpContext.User.FindFirstValue(ClaimTypes.Name),
                out var userId))
            {
                return BadRequest("Користувача не знайдено.");
            }

            var patients = await patientService.GetShortByDoctorUserAsync(userId, cancellationToken);
            return Ok(patients);
        }
    }
}
