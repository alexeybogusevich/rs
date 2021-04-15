using KNU.RS.Data.Context;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Study;
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

        public async Task<IEnumerable<StudyInfo>> GetInfoAsync(Guid patientId)
        {
            return await context.StudyHeaders
                .Include(s => s.StudyDetails)
                    .ThenInclude(s => s.StudySubtype)
                        .ThenInclude(s => s.StudyType)
                .Where(s => s.DoctorPatient.PatientId.Equals(patientId))
                .Select(s => StudyConverter.Convert(s))
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await context.StudyHeaders.CountAsync();
        }
    }
}
