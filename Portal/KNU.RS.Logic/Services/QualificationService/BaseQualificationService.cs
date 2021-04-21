using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.QualificationService
{
    public class BaseQualificationService : IQualificationService
    {
        private readonly ApplicationContext context;

        public BaseQualificationService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Qualification>> GetAsync()
        {
            return await context.Qualifications.ToListAsync();
        }
    }
}
