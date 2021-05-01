using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.Patient;
using System;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class PatientConverter
    {
        public static PatientInfo Convert(Patient patient)
        {
            return new PatientInfo
            {
                UserId = patient.UserId,
                PatientId = patient.Id,
                FirstName = patient.User?.FirstName,
                LastName = patient.User?.LastName,
                MiddleName = patient.User?.MiddleName,
                Gender = patient.User?.Gender ?? Gender.Male,
                PhoneNumber = patient.User?.PhoneNumber,
                Email = patient.User?.Email,
                Address = patient.User?.Address,
                Birthday = patient.User?.Birthday,
                Age = patient.User?.Birthday == null ? null : DateTimeHelper.GetAge(patient.User.Birthday),
                FormattedBirthday = patient.User?.Birthday == null ? string.Empty : patient.User.Birthday.ToString("dd.MM.yyyy"),
                HasPhoto = patient.User?.HasPhoto ?? false,
                Weight = patient.Weight,
                Height = patient.Height,
                MaritalStatus = patient.MaritalStatus,
                EducationStatus = patient.EducationStatus,
                Occupation = patient.Occupation,
                Job = patient.Job,
                Position = patient.Position,
                HealthInsuranse = patient.HealthInsuranse,
                HealthInsuranseCompany = patient.HealthInsuranseCompany,
                Passport = patient.Passport,
                Complaints = patient.Complaints,
                Diagnosis = patient.Diagnosis,
                RegistrationDate = patient.RegistrationDate
            };
        }

        public static PatientRegistrationModel ConvertProfile(Patient patient)
        {
            return new PatientRegistrationModel
            {
                Address = patient.User?.Address,
                Birthday = patient.User?.Birthday ?? DateTime.MinValue,
                Email = patient.User?.Email,
                FirstName = patient.User?.FirstName,
                LastName = patient.User?.LastName,
                MiddleName = patient.User?.MiddleName,
                Gender = patient.User?.Gender ?? Gender.Male,
                PhoneNumber = patient.User?.PhoneNumber,
                Height = patient.Height,
                Weight = patient.Weight,
                MaritalStatus = patient.MaritalStatus,
                EducationStatus = patient.EducationStatus,
                Occupation = patient.Occupation,
                Job = patient.Job,
                Position = patient.Position,
                HealthInsuranse = patient.HealthInsuranse,
                HealthInsuranseCompany = patient.HealthInsuranseCompany,
                Passport = patient.Passport,
                Complaints = patient.Complaints,
                Diagnosis = patient.Diagnosis
            };
        }

        public static PatientShort ConvertShort(Patient patient)
        {
            return new PatientShort
            {
                Id = patient.Id,
                FullName = $"{patient.User?.LastName} {patient.User?.FirstName} {patient.User?.MiddleName}",
                BirthDay = patient.User?.Birthday,
                Doctors = patient.Doctors?.Select(d => d.DoctorId)
            };
        }
    }
}
