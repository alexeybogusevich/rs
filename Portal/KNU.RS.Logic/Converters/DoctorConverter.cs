using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.Doctor;
using System;

namespace KNU.RS.Logic.Converters
{
    public static class DoctorConverter
    {
        public static DoctorInfo Convert(Doctor doctor)
        {
            return new DoctorInfo
            {
                Id = doctor.Id,
                UserId = doctor.UserId,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                PhoneNumber = doctor.User?.PhoneNumber,
                Address = doctor.User?.Address,
                Birthday = doctor.User?.Birthday,
                Age = doctor.User?.Birthday == null ? null : DateTimeHelper.GetAge(doctor.User.Birthday),
                FormattedBirthday = doctor.User?.Birthday == null ? string.Empty : doctor.User.Birthday.ToString("dd.MM.yyyy"),
                Gender = doctor.User?.Gender ?? Gender.Male,
                HasPhoto = doctor.User?.HasPhoto ?? false,
                Biography = doctor.Biography,
                Competencies = doctor.Competencies,
                Degree = doctor.Degree,
                QualificationId = doctor.QualificationId,
                QualificationName = doctor.Qualification?.Name,
                Room = doctor.Room,
                ClinicId = doctor.ClinicId,
                ClinicName = doctor.Clinic?.Name,
                ClinicAddress = doctor.Clinic?.Location,
                ClinicPhoneNumber = doctor.Clinic?.PhoneNumber,
                ClinicWorkingHours = doctor.Clinic?.WorkingHours
            };
        }

        public static DoctorRegistrationModel ConvertProfile(Doctor doctor)
        {
            return new DoctorRegistrationModel
            {
                Address = doctor.User?.Address,
                Biography = doctor.Biography,
                Competencies = doctor.Competencies,
                Degree = doctor.Degree,
                Birthday = doctor.User?.Birthday ?? DateTime.MinValue,
                ClinicId = doctor.ClinicId,
                Room = doctor.Room,
                Email = doctor.User?.Email,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                Gender = doctor.User?.Gender ?? Gender.Male,
                PhoneNumber = doctor.User?.PhoneNumber,
                QualificationId = doctor.QualificationId
            };
        }
    }
}
