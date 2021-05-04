using KNU.RS.Data.Constants;
using KNU.RS.Logic.Services.ReportService;
using KNU.RS.Logic.Services.StudyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace KNU.RS.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Doctor)]
    public class StudyReportsController : ControllerBase
    {
        private readonly IStudyService studyService;
        private readonly IReportService reportService;

        public StudyReportsController(IStudyService studyService, IReportService reportService)
        {
            this.studyService = studyService;
            this.reportService = reportService;
        }

        [HttpGet("{headerId}")]
        [Produces("text/plain")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid headerId)
        {
            var reportInfo = await studyService.GetReportAsync(headerId);

            if (reportInfo == null)
            {
                return NotFound($"Звіт не знайдено.");
            }

            var reportContent = await reportService.GetReportAsync(reportInfo);

            var sbFilename = new StringBuilder();
            sbFilename.Append(reportInfo.Fullname.Replace(" ", string.Empty));
            sbFilename.Append(reportInfo.Date.Replace(".", string.Empty));
            sbFilename.Append(".docx");

            return File(reportContent, "application/force-download", sbFilename.ToString());
        }
    }
}
