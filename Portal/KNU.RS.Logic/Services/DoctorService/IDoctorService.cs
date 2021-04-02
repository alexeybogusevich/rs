using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Doctor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> CreateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task<IEnumerable<DoctorInfo>> GetInfoAsync();
    }
}