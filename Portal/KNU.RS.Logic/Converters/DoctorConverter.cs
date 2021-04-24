using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
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
                UserId = doctor.UserId,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                PhoneNumber = doctor.User?.PhoneNumber,
                Address = doctor.User?.Address,
                Birthday = doctor.User?.Birthday,
                FormattedBirthday = doctor.User?.Birthday == null ? string.Empty : doctor.User.Birthday.ToString("dd.MM.yyyy"),
                Gender = doctor.User?.Gender ?? Gender.Male,
                HasPhoto = doctor.User?.HasPhoto ?? false,
                Biography = doctor.Biography,
                QualificationId = doctor.QualificationId,
                QualificationName = doctor.Qualification?.Name,
                ClinicId = doctor.ClinicId,
                ClinicName = doctor.Clinic?.Name,
                ClinicAddress = doctor.Clinic?.Location,
                ClinicPhoneNumber = doctor.Clinic?.PhoneNumber
            };
        }

        public static DoctorRegistrationModel ConvertProfile(Doctor doctor)
        {
            return new DoctorRegistrationModel
            {
                Address = doctor.User?.Address,
                Biography = doctor.Biography,
                Birthday = doctor.User?.Birthday ?? DateTime.MinValue,
                ClinicId = doctor.ClinicId,
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
