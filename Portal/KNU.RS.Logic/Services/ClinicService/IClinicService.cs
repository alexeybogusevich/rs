using KNU.RS.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ClinicService
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> GetAsync();
    }
}