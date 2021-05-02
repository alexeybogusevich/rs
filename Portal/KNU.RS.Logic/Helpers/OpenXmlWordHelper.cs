using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace KNU.RS.Logic.Helpers
{
    public static class OpenXmlWordHelper
    {
        public static string GetDocument()
        {
            var document = WordprocessingDocument.Create("", WordprocessingDocumentType.Document);

            var fields = document.GetMergeFields();

            return string.Empty;
        }

        public static IEnumerable<FieldCode> GetMergeFields(this WordprocessingDocument doc, string mergeFieldName = null)
        {
            if (doc == null)
                return null;

            List<FieldCode> mergeFields = doc.MainDocumentPart.RootElement.Descendants<FieldCode>().ToList();
            foreach (var header in doc.MainDocumentPart.HeaderParts)
            {
                mergeFields.AddRange(header.RootElement.Descendants<FieldCode>());
            }
            foreach (var footer in doc.MainDocumentPart.FooterParts)
            {
                mergeFields.AddRange(footer.RootElement.Descendants<FieldCode>());
            }

            if (!string.IsNullOrWhiteSpace(mergeFieldName) && mergeFields != null && mergeFields.Count > 0)
                return mergeFields.WhereNameIs(mergeFieldName);

            return mergeFields;
        }

        public static IEnumerable<FieldCode> GetMergeFields(this OpenXmlElement xmlElement, string mergeFieldName = null)
        {
            if (xmlElement == null)
                return null;

            if (string.IsNullOrWhiteSpace(mergeFieldName))
                return xmlElement
                    .Descendants<FieldCode>();

            return xmlElement
                .Descendants<FieldCode>()
                .Where(f => f.InnerText.StartsWith(GetMergeFieldStartString(mergeFieldName)));
        }

        public static IEnumerable<FieldCode> WhereNameIs(this IEnumerable<FieldCode> mergeFields, string mergeFieldName)
        {
            if (mergeFields == null || !mergeFields.Any())
                return null;

            return mergeFields
                .Where(f => f.InnerText.StartsWith(GetMergeFieldStartString(mergeFieldName)));
        }

        public static void ReplaceMergeFieldWithText(IEnumerable<FieldCode> fields, string mergeFieldName, string replacementText)
        {
            var field = fields
                .Where(f => f.InnerText.Contains(mergeFieldName))
                .FirstOrDefault();

            if (field != null)
            {
                Run rFldCode = (Run)field.Parent;

                Run rBegin = rFldCode.PreviousSibling<Run>();
                Run rSep = rFldCode.NextSibling<Run>();
                Run rText = rSep.NextSibling<Run>();
                Run rEnd = rText.NextSibling<Run>();

                Text t = rText.GetFirstChild<Text>();
                t.Text = replacementText;

                rFldCode.Remove();
                rBegin.Remove();
                rSep.Remove();
                rEnd.Remove();
            }

        }
        public static Paragraph GetParagraph(this OpenXmlElement xmlElement)
        {
            if (xmlElement == null)
                return null;

            Paragraph paragraph = xmlElement is Paragraph
                ? (Paragraph)xmlElement
                : xmlElement.Parent is Paragraph ?
                (Paragraph)xmlElement.Parent : xmlElement.Ancestors<Paragraph>().FirstOrDefault();

            return paragraph;
        }

        public static void ReplaceWithText(this FieldCode field, string replacementText)
        {
            if (field == null)
                return;

            Run rFldCode = field.Parent as Run;
            Run rBegin = rFldCode.PreviousSibling<Run>();
            Run rSep = rFldCode.NextSibling<Run>();
            Run rText = rSep.NextSibling<Run>();
            Run rEnd = rText.NextSibling<Run>();

            rFldCode.Remove();
            rBegin.Remove();
            rSep.Remove();
            rEnd.Remove();

            Text t = rText.GetFirstChild<Text>();
            if (t != null)
            {
                t.Text = replacementText ?? string.Empty;
            }
        }

        public static void ReplaceWithText(this IEnumerable<FieldCode> fields, string replacementText)
        {
            if (fields == null || !fields.Any())
                return;

            foreach (var field in fields)
            {
                field.ReplaceWithText(replacementText);
            }
        }

        public static void ReplaceWithText(this IEnumerable<FieldCode> fields, IEnumerable<string> replacementTexts, bool removeExcess = false)
        {
            if (fields == null || !fields.Any())
                return;

            int replacementCount = replacementTexts.Count();
            int index = 0;
            foreach (var field in fields)
            {
                if (index < replacementCount)
                    field.ReplaceWithText(replacementTexts.ElementAt(index));
                else if (removeExcess)
                    field.GetParagraph().Remove();
                else
                    field.ReplaceWithText(string.Empty);

                index++;
            }
        }

        private static string GetMergeFieldStartString(string mergeFieldName)
        {
            return " MERGEFIELD  " + (!string.IsNullOrWhiteSpace(mergeFieldName) ? mergeFieldName : "<NoNameMergeField>");
        }
    }
}
