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
        Task<IEnumerable<StudyInfo>> GetInfoAsync(Guid patientId);
        Task<IEnumerable<StudyDetailsInfo>> GetDetailsInfoAsync(Guid patientId);
        Task<StudyReportInfo> GetReportAsync(Guid headerId);
        Task<IEnumerable<StudySubtype>> GetSubtypesAsync();
        Task<int> GetCountAsync();
        Task<StudyHeader> SaveAsync(StudyModel study, Guid userId);
    }
}