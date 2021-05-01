using KNU.RS.Data.Context;
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

        public async Task<PatientInfo> GetInfoAsync(Guid userId)
        {
            var patient = await context.Patients
                .Include(p => p.User)
                .FirstOrDefaultAsync(d => d.UserId.Equals(userId));

            return PatientConverter.Convert(patient);
        }

        public async Task<IEnumerable<PatientShort>> GetShortAsync()
        {
            return await context.Patients
                .Include(p => p.User)
                .Include(p => p.Doctors)
                .Select(p => PatientConverter.ConvertShort(p))
                .ToListAsync();
        }

        public async Task<Patient> GetAsync(Guid userId)
        {
            return await context.Patients
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.UserId.Equals(userId));
        }

        public async Task<IEnumerable<PatientInfo>> GetInfoByDoctorAsync(Guid doctorId)
        {
            return await context.Patients
                .Include(p => p.User)
                .Include(p => p.Doctors)
                .Where(p => p.Doctors.Select(d => d.DoctorId).Contains(doctorId))
                .Select(p => PatientConverter.Convert(p))
                .ToListAsync();
        }

        public async Task AssignToDoctorAsync(Guid patientId, Guid doctorId)
        {
            var doctorPatient = new DoctorPatient { PatientId = patientId, DoctorId = doctorId };
            await context.DoctorPatients.AddAsync(doctorPatient);
            await context.SaveChangesAsync();
        }
    }
}
