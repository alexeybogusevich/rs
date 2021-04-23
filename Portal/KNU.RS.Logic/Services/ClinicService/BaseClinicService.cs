using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ClinicService
{
    public class BaseClinicService : IClinicService
    {
        private readonly ApplicationContext context;

        public BaseClinicService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Clinic>> GetAsync()
        {
            return await context.Clinics.ToListAsync();
        }
    }
}
