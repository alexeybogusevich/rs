using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await context.Doctors
                .Include(d => d.Clinic)
                .Include(d => d.Qualification)
                .Include(d => d.User)
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

        public async Task DeleteAsync(Doctor doctor)
        {
            context.Doctors.Remove(doctor);
            await context.SaveChangesAsync();
        }
    }
}
