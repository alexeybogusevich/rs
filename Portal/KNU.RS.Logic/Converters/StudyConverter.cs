using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class StudyConverter
    {
        public static StudyInfo Convert(StudyHeader studyHeader)
        {
            var doctor = studyHeader.DoctorPatient?.Doctor?.User;
            return new StudyInfo
            {
                Id = studyHeader.Id,
                DateTime = studyHeader.DateTime,
                DoctorId = studyHeader.DoctorPatient.DoctorId,
                DoctorFullName = $"{doctor?.LastName} {doctor?.FirstName} {doctor?.MiddleName}",
                StudyTypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyTypeId,
                StudyTypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyType?.Name,
                StudyDetails = studyHeader.StudyDetails?.Select(s =>
                    new StudyDetailsShort
                    {
                        StudySubtypeName = s.StudySubtype?.Name,
                        ClockwiseDegrees = s.ClockwiseDegrees,
                        CounterClockwiseDegrees = s.CounterClockwiseDegrees
                    })
            };
        }

        public static StudyDetailsInfo Convert(StudyDetails studyDetails)
        {
            return new StudyDetailsInfo
            {
                Id = studyDetails.Id,
                SerialNumber = studyDetails.StudySubtype?.SerialNumber ?? default,
                StudyHeaderId = studyDetails.StudyHeaderId,
                ClockwiseDegrees = studyDetails.ClockwiseDegrees,
                CounterClockwiseDegrees = studyDetails.CounterClockwiseDegrees,
                DateTime = studyDetails.StudyHeader?.DateTime,
                StudySubtypeId = studyDetails.StudySubtypeId,
                StudySubtypeName = studyDetails.StudySubtype?.Name,
                StudyTypeId = studyDetails.StudySubtype?.StudyTypeId,
                StudyTypeName = studyDetails.StudySubtype?.StudyType?.Name
            };
        }
    }
}
