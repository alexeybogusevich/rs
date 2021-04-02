using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Doctor;

namespace KNU.RS.Logic.Converters
{
    public static class DoctorConverter
    {
        public static DoctorInfo Convert(Doctor doctor)
        {
            return new DoctorInfo
            {
                Id = doctor.Id,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                PhoneNumber = doctor.User?.PhoneNumber,
                Address = doctor.User?.Address,
                QualificationId = doctor.QualificationId,
                QualificationName = doctor.Qualification?.Name,
                ClinicId = doctor.ClinicId,
                ClinicName = doctor.Clinic?.Name,
                ClinicAddress = doctor.Clinic?.Location,
                ClinicPhoneNumber = doctor.Clinic?.PhoneNumber
            };
        }
    }
}
