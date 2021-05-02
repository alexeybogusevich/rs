using KNU.RS.Logic.Models.Study;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ReportService
{
    public interface IReportService
    {
        Task<byte[]> GetReportAsync(StudyReportInfo reportInfo);
    }
}