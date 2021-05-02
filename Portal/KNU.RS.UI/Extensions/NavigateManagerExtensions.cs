using Microsoft.AspNetCore.Components;

namespace KNU.RS.UI.Extensions
{
    public static class NavigateManagerExtensions
    {
        public static void NavigateUnauthorized(this NavigationManager navManager)
        {
            navManager.NavigateTo("/signin");
        }
    }
}
