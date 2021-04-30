using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using System;
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
                DateTime = studyHeader.DateTime,
                StudyTypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyTypeId,
                StudyTypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.StudyType?.Name,
                StudySubtypeId = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtypeId,
                StudySubtypeName = studyHeader.StudyDetails?.FirstOrDefault()?.StudySubtype?.Name
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
