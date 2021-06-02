using KNU.RS.Data.Constants;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.StudyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Doctor)]
    public class StudyTypesController : ControllerBase
    {
        private readonly IStudyService studyService;

        public StudyTypesController(IStudyService studyService)
        {
            this.studyService = studyService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudyTypeInfo>), 200)]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult<IEnumerable<StudyTypeInfo>>> GetAsync(CancellationToken cancellationToken)
        {
            var subtypes = await studyService.GetTypesAsync(cancellationToken);
            var response = subtypes.Select(s => StudyConverter.ConvertType(s));
            return Ok(response);
        }

        [HttpGet("subtypes")]
        [ProducesResponseType(typeof(IEnumerable<StudySubtypeInfo>), 200)]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult<IEnumerable<StudySubtypeInfo>>> GetSubtypesAsync(CancellationToken cancellationToken)
        {
            var subtypes = await studyService.GetSubtypesAsync(cancellationToken);
            var response = subtypes.Select(s => StudyConverter.ConvertSubtype(s));
            return Ok(response);
        }
    }
}
