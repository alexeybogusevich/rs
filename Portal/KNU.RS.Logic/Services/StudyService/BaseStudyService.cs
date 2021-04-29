using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
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

        public async Task<IEnumerable<StudySubtype>> GetSubtypesAsync()
        {
            return await context.StudySubtypes.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await context.StudyHeaders.CountAsync();
        }

        public async Task<StudyHeader> SaveAsync(StudyModel study, Guid userId)
        {
            var doctorPatient = await context.DoctorPatients
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(dp => 
                    dp.Doctor.UserId.Equals(userId) 
                    && dp.PatientId.Equals(study.PatientId));

            if (doctorPatient == null)
            {
                return null;
            }

            var studyHeader = new StudyHeader
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                DoctorPatientId = doctorPatient.Id
            };
            await context.StudyHeaders.AddAsync(studyHeader);

            var studyDetails = study.StudyDetails.Select(s =>
                new StudyDetails
                {
                    Id = Guid.NewGuid(),
                    ClockwiseDegrees = s.ClockwiseDegrees,
                    CounterClockwiseDegrees = s.CounterClockwiseDegrees,
                    StudySubtypeId = s.StudySubtypeId,
                    StudyHeaderId = studyHeader.Id
                });

            await context.StudyDetails.AddRangeAsync(studyDetails);
            await context.SaveChangesAsync();

            return studyHeader;
        }
    }
}
