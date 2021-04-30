using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.StudyService
{
    public interface IStudyService
    {
        Task<IEnumerable<StudyInfo>> GetInfoAsync();
        Task<IEnumerable<StudyDetailsInfo>> GetDetailsInfoAsync(Guid patientId);
        Task<IEnumerable<StudySubtype>> GetSubtypesAsync();
        Task<int> GetCountAsync();
        Task<StudyHeader> SaveAsync(StudyModel study, Guid userId);
    }
}