using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Clinic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ClinicModel>> GetModelAsync(CancellationToken cancellationToken = default);
        Task<ClinicModel> GetModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(ClinicModel model);
        Task UpdateAsync(ClinicModel model);
        Task DeleteAsync(Guid id);
    }
}