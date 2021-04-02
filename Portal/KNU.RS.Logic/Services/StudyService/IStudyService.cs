using KNU.RS.Logic.Models.Study;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.StudyService
{
    public interface IStudyService
    {
        Task<IEnumerable<StudyInfo>> GetAsync(Guid patientId);
    }
}