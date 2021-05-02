using System.Collections.Generic;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyReportInfo
    {
        public string Fullname { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string DoctorShortName { get; set; }
        public string StudyTypeName { get; set; }
        public string Date { get; set; }
        public string Complaints { get; set; }
        public string Diagnosis { get; set; }
        public IEnumerable<StudyDetailsShort> StudyDetails { get; set; }
    }
}
