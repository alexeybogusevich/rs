using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected bool IsLoading { get; set; }

        protected readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        public void Dispose()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
        }
    }
}
