using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Study;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ReportService
{
    public class BaseReportService : IReportService
    {
        private readonly ReportConfiguration configuration;

        public BaseReportService(IOptions<ReportConfiguration> options)
        {
            configuration = options.Value;
        }

        public async Task<byte[]> GetReportAsync(StudyReportInfo reportInfo)
        {
            var sourceFile = Path.GetFullPath(configuration.FullPath);
            var tempFile = Path.GetFullPath(configuration.TempPath);
            File.Copy(sourceFile, tempFile);

            using var document = WordprocessingDocument.Open(tempFile, true);
            document.ChangeDocumentType(WordprocessingDocumentType.Document);

            MainDocumentPart mainPart = document.MainDocumentPart;
            var mergeFields = mainPart.RootElement.Descendants<FieldCode>();

            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Date, reportInfo.Date);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.FullName, reportInfo.Fullname);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.PhoneNumber, reportInfo.PhoneNumber);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Age, reportInfo.Age);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Doctor, reportInfo.DoctorShortName);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Doctor, reportInfo.DoctorShortName);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Weight, reportInfo.Weight);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Height, reportInfo.Height);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Diagnosis, reportInfo.Diagnosis);
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.Complaints, reportInfo.Complaints);

            document.Save();
            document.Close();

            var content = await File.ReadAllBytesAsync(tempFile);
            File.Delete(tempFile);

            return content;
        }
    }
}
