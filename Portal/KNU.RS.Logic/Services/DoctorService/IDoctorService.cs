using KNU.RS.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
    }
}