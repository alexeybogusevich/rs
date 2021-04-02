using KNU.RS.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PatientService
{
    public interface IPatientService
    {
        Task<Patient> CreateAsync(Patient patient);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<Patient>> GetPatientsAsync(Guid doctorId);
        Task<Patient> UpdateAsync(Patient patient);
    }
}