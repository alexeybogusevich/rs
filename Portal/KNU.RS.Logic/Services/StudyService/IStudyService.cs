using KNU.RS.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.StudyService
{
    public interface IStudyService
    {
        Task<IEnumerable<StudyHeader>> GetStudiesAsync(Guid patientId);
    }
}