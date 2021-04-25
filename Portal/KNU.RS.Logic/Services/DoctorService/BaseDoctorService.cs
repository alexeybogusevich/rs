using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.DoctorService
{
    public class BaseDoctorService : IDoctorService
    {
        private readonly ApplicationContext context;

        public BaseDoctorService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Doctor> GetAsync(Guid userId)
        {
            return await context.Doctors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.UserId.Equals(userId));
        }

        public async Task<DoctorInfo> GetInfoAsync(Guid userId)
        {
            return await context.Doctors
                .Include(d => d.Clinic)
                .Include(d => d.Qualification)
                .Include(d => d.User)
                .Select(d => DoctorConverter.Convert(d))
                .FirstOrDefaultAsync(d => d.UserId.Equals(userId));
        }

        public async Task<IEnumerable<DoctorInfo>> GetInfoAsync()
        {
            return await context.Doctors
                .Include(d => d.Clinic)
                .Include(d => d.Qualification)
                .Include(d => d.User)
                .Select(d => DoctorConverter.Convert(d))
                .ToListAsync();
        }

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await context.Doctors.AddAsync(doctor);
            await context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateAsync(Doctor doctor)
        {
            context.Doctors.Update(doctor);
            await context.SaveChangesAsync();
            return doctor;
        }
    }
}
