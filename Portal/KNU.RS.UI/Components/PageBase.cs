using KNU.RS.Logic.Helpers;
using Microsoft.AspNetCore.Components;

namespace KNU.RS.UI.Components
{
    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
    }
}
