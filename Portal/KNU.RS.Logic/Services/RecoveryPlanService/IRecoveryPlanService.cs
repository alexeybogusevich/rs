using KNU.RS.Logic.Models.Recovery;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.RecoveryPlanService
{
    public interface IRecoveryPlanService
    {
        Task<IEnumerable<RecoveryDailyPlanInfo>> GetInfoAsync(Guid patientId);
        Task<bool> MarkAsCompletedAsync(Guid id);
        Task CreateAsync(RecoveryDailyPlanModel model, Guid doctorId, Guid patientId);
        Task DeleteAsync(Guid id);
    }
}