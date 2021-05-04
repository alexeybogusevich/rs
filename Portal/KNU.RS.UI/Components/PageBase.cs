using Microsoft.AspNetCore.Components;
using System;
using System.Threading;

namespace KNU.RS.UI.Components
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public void Dispose()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
        }
    }
}
