using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class StudyConverter
    {
        public static StudyInfo Convert(StudyHeader studyHeader)
        {
            return new StudyInfo
            {
                Id = studyHeader.Id,
                Complaints = studyHeader.Complaints,
                Diagnosis = studyHeader.Diagnosis,
                Notes = studyHeader.Notes,
                StudyTypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyTypeId,
                StudyTypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyType?.Name,
                StudySubtypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtypeId,
                StudySubtypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.Name
            };
        }
    }
}
