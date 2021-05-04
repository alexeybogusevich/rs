using KNU.RS.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.QualificationService
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> GetAsync(CancellationToken cancellationToken = default);
    }
}