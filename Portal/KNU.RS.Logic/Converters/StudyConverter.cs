using KNU.RS.Data.Models;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Study;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class StudyConverter
    {
        public static StudyInfo Convert(StudyHeader studyHeader)
        {
            var doctorUser = studyHeader.DoctorPatient?.Doctor?.User;
            return new StudyInfo
            {
                Id = studyHeader.Id,
                DateTime = studyHeader.DateTime,
                DoctorId = studyHeader?.DoctorPatient?.DoctorId,
                DoctorUserId = doctorUser?.Id,
                DoctorFullName = $"{doctorUser?.LastName} {doctorUser?.FirstName} {doctorUser?.MiddleName}",
                DoctorShortName = $"{doctorUser?.LastName} {doctorUser?.FirstName?.FirstOrDefault()}. {doctorUser?.MiddleName?.FirstOrDefault()}.",
                StudyTypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyTypeId,
                StudyTypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyType?.Name,
                StudyDetails = studyHeader.StudyDetails?.Select(s =>
                    new StudyDetailsShort
                    {
                        StudySubtypeName = s.StudySubtype?.Name,
                        MinClockwiseDegrees = s.MinClockwiseDegrees,
                        AvgClockwiseDegrees = s.AvgClockwiseDegrees,
                        MaxClockwiseDegrees = s.MaxClockwiseDegrees,
                        MinCounterClockwiseDegrees = s.MinCounterClockwiseDegrees,
                        AvgCounterClockwiseDegrees = s.AvgCounterClockwiseDegrees,
                        MaxCounterClockwiseDegrees = s.MaxCounterClockwiseDegrees
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
                MinClockwiseDegrees = studyDetails.MinClockwiseDegrees,
                AvgClockwiseDegrees = studyDetails.AvgClockwiseDegrees,
                MaxClockwiseDegrees = studyDetails.MaxClockwiseDegrees,
                MinCounterClockwiseDegrees = studyDetails.MinCounterClockwiseDegrees,
                AvgCounterClockwiseDegrees = studyDetails.AvgCounterClockwiseDegrees,
                MaxCounterClockwiseDegrees = studyDetails.MaxCounterClockwiseDegrees,
                DateTime = studyDetails.StudyHeader?.DateTime,
                StudySubtypeId = studyDetails.StudySubtypeId,
                StudySubtypeName = studyDetails.StudySubtype?.Name,
                StudyTypeId = studyDetails.StudySubtype?.StudyTypeId,
                StudyTypeName = studyDetails.StudySubtype?.StudyType?.Name
            };
        }

        public static StudyReportInfo ConvertReport(StudyHeader studyHeader)
        {
            var doctorUser = studyHeader.DoctorPatient?.Doctor?.User;
            var patientUser = studyHeader.DoctorPatient?.Patient?.User;

            return new StudyReportInfo
            {
                Age = patientUser?.Birthday == null ? string.Empty : DateTimeHelper.GetAge(patientUser.Birthday).ToString(),
                Complaints = studyHeader.DoctorPatient?.Patient?.Complaints ?? string.Empty,
                Diagnosis = studyHeader.DoctorPatient?.Patient?.Diagnosis ?? string.Empty,
                Date = studyHeader.DateTime.ToString("dd.MM.yyyy"),
                DoctorShortName = doctorUser == null ? string.Empty : NameHelper.GetShortName(doctorUser),
                Fullname = patientUser == null ? string.Empty : NameHelper.GetFullName(patientUser),
                PhoneNumber = patientUser.PhoneNumber?.ToString() ?? string.Empty,
                Height = studyHeader.DoctorPatient?.Patient?.Height.ToString() ?? string.Empty,
                Weight = studyHeader.DoctorPatient?.Patient?.Weight.ToString() ?? string.Empty,
                StudyTypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyType?.Name ?? string.Empty,
                StudyDetails = studyHeader.StudyDetails?.Select(s =>
                    new StudyDetailsShort
                    {
                        StudySubtypeName = s.StudySubtype?.Name,
                        MinClockwiseDegrees = s.MinClockwiseDegrees,
                        AvgClockwiseDegrees = s.AvgClockwiseDegrees,
                        MaxClockwiseDegrees = s.MaxClockwiseDegrees,
                        MinCounterClockwiseDegrees = s.MinCounterClockwiseDegrees,
                        AvgCounterClockwiseDegrees = s.AvgCounterClockwiseDegrees,
                        MaxCounterClockwiseDegrees = s.MaxCounterClockwiseDegrees
                    })
            };
        }
    }
}
