using KNU.RS.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.RecoveryPlanService
{
    public interface IRecoveryPlanService
    {
        Task<RecoveryDailyPlan> CreateAsync(RecoveryDailyPlan dailyPlan);
        Task<IEnumerable<RecoveryDailyPlan>> GetAsync(Guid patientId);
    }
}