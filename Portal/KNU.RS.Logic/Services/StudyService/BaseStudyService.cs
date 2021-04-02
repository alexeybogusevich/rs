using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.StudyService
{
    public class BaseStudyService : IStudyService
    {
        private readonly ApplicationContext context;

        public BaseStudyService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<StudyHeader>> GetStudiesAsync(Guid patientId)
        {
            return await context.StudyHeaders
                .Include(s => s.StudyDetails)
                    .ThenInclude(s => s.StudySubtype)
                        .ThenInclude(s => s.StudyType)
                .Where(s => s.DoctorPatient.PatientId.Equals(patientId))
                .ToListAsync();
        }
    }
}
