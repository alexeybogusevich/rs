using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Clinic;

namespace KNU.RS.Logic.Converters
{
    public static class ClinicConverter
    {
        public static ClinicModel Convert(Clinic clinic)
        {
            return new ClinicModel
            {
                Id = clinic.Id,
                Location = clinic.Location,
                Name = clinic.Name,
                PhoneNumber = clinic.PhoneNumber,
                WorkingHours = clinic.WorkingHours
            };
        }
    }
}
