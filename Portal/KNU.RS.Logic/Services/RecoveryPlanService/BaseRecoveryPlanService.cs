using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
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

        public async Task<IEnumerable<RecoveryDailyPlan>> GetAsync(Guid patientId)
        {
            return await context.RecoveryDailyPlans
                .Include(p => p.DoctorPatient)
                .Where(p => p.DoctorPatient.PatientId.Equals(patientId))
                .ToListAsync();
        }

        public async Task<RecoveryDailyPlan> CreateAsync(RecoveryDailyPlan dailyPlan)
        {
            await context.RecoveryDailyPlans.AddAsync(dailyPlan);
            await context.SaveChangesAsync();
            return dailyPlan;
        }
    }
}
