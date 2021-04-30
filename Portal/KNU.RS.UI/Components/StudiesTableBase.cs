using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.StudyService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace KNU.RS.UI.Components
{
    public class StudiesTableBase : ComponentBase
    {
        [Parameter]
        public List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();
    }
}
