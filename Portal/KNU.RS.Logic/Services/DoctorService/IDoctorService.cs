using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> GetAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<DoctorInfo> GetInfoAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DoctorInfo>> GetInfoAsync(CancellationToken cancellationToken = default);
    }
}