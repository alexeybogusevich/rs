using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Recovery;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class RecoveryConverter
    {
        public static RecoveryDailyPlanInfo Convert(RecoveryDailyPlan plan)
        {
            var doctorUser = plan.DoctorPatient?.Doctor?.User;
            return new RecoveryDailyPlanInfo
            {
                Id = plan.Id,
                Completed = plan.Completed,
                DoctorId = doctorUser?.Id,
                SerialNumber = plan.SerialNumber,
                Name = plan.Name,
                Description = plan.Description,
                Times = plan.Times,
                DateTime = plan.Day,
                DoctorName = $"{doctorUser.LastName} {doctorUser.FirstName?.FirstOrDefault()}. {doctorUser.MiddleName?.FirstOrDefault()}."
            };
        }
    }
}
