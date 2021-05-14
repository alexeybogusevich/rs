using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Study;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.StudyService
{
    public interface IStudyService
    {
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StudyDetailsInfo>> GetDetailsInfoAsync(Guid patientId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StudyInfo>> GetInfoAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StudyInfo>> GetInfoAsync(Guid patientId, CancellationToken cancellationToken = default);
        Task<StudyReportInfo> GetReportAsync(Guid headerId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StudyType>> GetTypesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StudySubtype>> GetSubtypesAsync(CancellationToken cancellationToken = default);
        Task<StudyHeader> SaveAsync(StudyModel study, Guid userId);
    }
}