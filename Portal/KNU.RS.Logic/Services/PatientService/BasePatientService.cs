﻿using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PatientService
{
    public class BasePatientService : IPatientService
    {
        private readonly ApplicationContext context;

        public BasePatientService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PatientInfo>> GetInfoAsync()
        {
            return await context.Patients
                .Include(p => p.User)
                .Select(p => PatientConverter.Convert(p))
                .ToListAsync();
        }

        public async Task<IEnumerable<PatientInfo>> GetInfoAsync(Guid doctorId)
        {
            return await context.Patients
                .Include(p => p.User)
                .Where(p => p.Doctors.Select(d => d.DoctorId).Contains(doctorId))
                .Select(p => PatientConverter.Convert(p))
                .ToListAsync();
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            context.Patients.Update(patient);
            await context.SaveChangesAsync();
            return patient;
        }
    }
}