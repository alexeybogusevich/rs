﻿using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Patient;
using System;

namespace KNU.RS.Logic.Converters
{
    public static class PatientConverter
    {
        public static PatientInfo Convert(Patient patient)
        {
            return new PatientInfo
            {
                Id = patient.Id,
                FirstName = patient.User?.FirstName,
                LastName = patient.User?.LastName,
                MiddleName = patient.User?.MiddleName,
                Gender = patient.User?.Gender ?? Gender.Male,
                PhoneNumber = patient.User?.PhoneNumber,
                Email = patient.User?.Email,
                Address = patient.User?.Address,
                Birthday = patient.User?.Birthday,
                FormattedBirthday = patient.User?.Birthday == null ? string.Empty : patient.User.Birthday.ToString("dd.MM.yyyy"),
                Weight = patient.Weight,
                Height = patient.Height,
                Description = patient.Description
            };
        }
    }
}
