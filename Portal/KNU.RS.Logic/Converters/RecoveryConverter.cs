using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Recovery;
using System.Linq;

namespace KNU.RS.Logic.Converters
{
    public static class RecoveryConverter
    {
        public static RecoveryDailyPlanInfo Convert(RecoveryDailyPlan plan)
        {
            var doctor = plan.DoctorPatient?.Doctor?.User;
            return new RecoveryDailyPlanInfo
            {
                Id = plan.Id,
                DoctorId = plan.DoctorPatient?.DoctorId,
                SerialNumber = plan.SerialNumber,
                Name = plan.Name,
                Description = plan.Description,
                Times = plan.Times,
                DateTime = plan.Day,
                DoctorName = $"{doctor.LastName} {doctor.FirstName?.FirstOrDefault()}. {doctor.MiddleName?.FirstOrDefault()}."
            };
        }
    }
}
