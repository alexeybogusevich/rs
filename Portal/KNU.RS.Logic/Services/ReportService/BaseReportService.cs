using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Study;
using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
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
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), configuration.Path);
            var hash = CryptographyHelper.GetRandomMD5Hash();
            var extension = configuration.Path.Split(".").Last();
            var tempPath = Path.Combine(Path.GetTempPath(), $"{hash}.{extension}");

            var sourceFile = Path.GetFullPath(templatePath);
            var tempFile = Path.GetFullPath(tempPath);
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
            OpenXmlWordHelper.ReplaceMergeFieldWithText(mergeFields, ReportVariables.StudyType, reportInfo.StudyTypeName);

            var lastTable = mainPart.Document.Body.Descendants<Table>().LastOrDefault();

            if (lastTable != null)
            {
                var spacing = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto, Before = "0", After = "0" };
                var justification = new Justification { Val = JustificationValues.Center };

                var paragraphProperties = new ParagraphProperties();
                paragraphProperties.Append(spacing);
                paragraphProperties.Append(justification);

                var tableCellProperties = new TableCellProperties
                {
                    TableCellVerticalAlignment = new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                };

                foreach (var studyDetails in reportInfo.StudyDetails)
                {
                    var paragraph1 = new Paragraph(new Run(new Text(studyDetails.StudySubtypeName)))
                    {
                        ParagraphProperties = new ParagraphProperties(spacing.CloneNode(true) as SpacingBetweenLines)
                    };

                    var tableCell1 = new TableCell(paragraph1)
                    {
                        TableCellProperties = tableCellProperties.CloneNode(true) as TableCellProperties
                    };

                    var paragraph2 = new Paragraph(new Run(new Text(studyDetails.ClockwiseDegrees.ToString())))
                    {
                        ParagraphProperties = paragraphProperties.CloneNode(true) as ParagraphProperties
                    };

                    var tableCell2 = new TableCell(paragraph2)
                    {
                        TableCellProperties = tableCellProperties.CloneNode(true) as TableCellProperties
                    };

                    var paragraph3 = new Paragraph(new Run(new Text(studyDetails.CounterClockwiseDegrees.ToString())))
                    {
                        ParagraphProperties = paragraphProperties.CloneNode(true) as ParagraphProperties
                    };

                    var tableCell3 = new TableCell(paragraph3)
                    {
                        TableCellProperties = tableCellProperties.CloneNode(true) as TableCellProperties
                    };

                    lastTable.Append(new TableRow(tableCell1, tableCell2, tableCell3));
                }
            }

            document.Save();
            document.Close();

            var content = await File.ReadAllBytesAsync(tempFile);
            File.Delete(tempFile);

            return content;
        }
    }
}
