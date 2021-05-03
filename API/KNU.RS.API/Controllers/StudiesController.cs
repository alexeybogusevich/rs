using KNU.RS.Data.Constants;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.StudyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Doctor)]
    public class StudiesController : ControllerBase
    {
        private readonly IStudyService studyService;

        public StudiesController(IStudyService studyService)
        {
            this.studyService = studyService;
        }

        [HttpGet("subtypes")]
        [ProducesResponseType(typeof(IEnumerable<StudySubtype>), 200)]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult<StudySubtype>> GetTypesAsync()
        {
            var subtypes = await studyService.GetSubtypesAsync();
            return Ok(subtypes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<StudyHeader>> SaveAsync([FromBody] StudyModel study)
        {
            if (!Guid.TryParse(
                HttpContext.User.FindFirstValue(ClaimTypes.Name),
                out var userId))
            {
                return BadRequest("Користувача не знайдено.");
            }

            var studyHeader = await studyService.SaveAsync(study, userId);
            if (studyHeader == null)
            {
                return BadRequest("Вказаного пацієнта не закріплено за лікарем.");
            }

            return Ok($"Результат збережено. Запис від {studyHeader.DateTime:dd.MM.yyyy HH:mm:ss}");
        }
    }
}
