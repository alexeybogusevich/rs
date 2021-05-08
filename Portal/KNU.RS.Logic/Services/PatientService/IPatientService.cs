using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Patient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PatientService
{
    public interface IPatientService
    {
        Task<Patient> GetAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<PatientInfo> GetInfoAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientInfo>> GetInfoAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientInfo>> GetInfoByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientInfo>> GetInfoByDoctorUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientShort>> GetShortAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientShort>> GetShortByDoctorUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task AssignToDoctorAsync(Guid patientId, Guid doctorId);
    }
}