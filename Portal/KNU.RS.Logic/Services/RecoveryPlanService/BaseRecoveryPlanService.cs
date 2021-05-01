using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Recovery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.RecoveryPlanService
{
    public class BaseRecoveryPlanService : IRecoveryPlanService
    {
        private readonly ApplicationContext context;

        public BaseRecoveryPlanService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<RecoveryDailyPlanInfo>> GetInfoAsync(Guid patientId)
        {
            return await context.RecoveryDailyPlans
                .Include(p => p.DoctorPatient)
                    .ThenInclude(dp => dp.Doctor)
                        .ThenInclude(d => d.User)
                .Where(p => p.DoctorPatient.PatientId.Equals(patientId))
                .Select(p => RecoveryConverter.Convert(p))
                .ToListAsync();
        }

        public async Task<bool> MarkAsCompletedAsync(Guid id)
        {
            var plan = await context.RecoveryDailyPlans.FindAsync(id);
            if (plan.Completed || (plan.Day < DateTime.Today) || (plan.Day > DateTime.Today.AddDays(1)))
            {
                return false;
            }

            plan.Completed = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task CreateAsync(RecoveryDailyPlanModel model, Guid doctorUserId, Guid patientId)
        {
            var doctorPatient = await context.DoctorPatients.Include(d => d.Doctor).FirstOrDefaultAsync(
                dp => dp.Doctor.UserId.Equals(doctorUserId) && dp.PatientId.Equals(patientId));

            if (doctorPatient == null)
            {
                return;
            }

            var dailyPlan = new RecoveryDailyPlan
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Completed = false,
                Day = model.Day,
                Times = model.Times,
                DoctorPatientId = doctorPatient.Id
            };

            await context.RecoveryDailyPlans.AddAsync(dailyPlan);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var plan = await context.RecoveryDailyPlans.FindAsync(id);
            if (plan == null)
            {
                return;
            }

            context.RecoveryDailyPlans.Remove(plan);
            await context.SaveChangesAsync();
        }
    }
}
