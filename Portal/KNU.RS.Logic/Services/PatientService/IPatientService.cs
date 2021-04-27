using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Patient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PatientService
{
    public interface IPatientService
    {
        Task<Patient> GetAsync(Guid userId);
        Task<IEnumerable<PatientInfo>> GetInfoAsync();
        Task<PatientInfo> GetInfoAsync(Guid userId);
        Task<IEnumerable<PatientInfo>> GetInfoByDoctorAsync(Guid doctorId);
        Task<Patient> CreateAsync(Patient patient);
        Task<Patient> UpdateAsync(Patient patient);
    }
}