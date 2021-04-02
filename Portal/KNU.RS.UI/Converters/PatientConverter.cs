using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Patient;

namespace KNU.RS.Logic.Converters
{
    public static class PatientConverter
    {
        public static PatientInfo Convert(Patient patient)
        {
            return new PatientInfo
            {
                Id = patient.Id,
                FirstName = patient.User?.FirstName,
                LastName = patient.User?.LastName,
                MiddleName = patient.User?.MiddleName,
                PhoneNumber = patient.User?.PhoneNumber,
                Address = patient.User?.Address,
                Birthday = patient.Birthday,
                Weight = patient.Weight,
                Height = patient.Height
            };
        }
    }
}
