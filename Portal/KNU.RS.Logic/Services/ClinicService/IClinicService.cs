using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Clinic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> GetAsync();
        Task<IEnumerable<ClinicModel>> GetModelAsync();
        Task<ClinicModel> GetModelAsync(Guid id);
        Task CreateAsync(ClinicModel model);
        Task UpdateAsync(ClinicModel model);
        Task DeleteAsync(Guid id);
    }
}