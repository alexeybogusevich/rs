﻿using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Patient;

namespace KNU.RS.Logic.Converters
{
    public static class PatientConverter
    {
        public static PatientInfo Convert(Patient patient)
        {
            return new PatientInfo
            {
                UserId = patient.UserId,
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
    }
}
