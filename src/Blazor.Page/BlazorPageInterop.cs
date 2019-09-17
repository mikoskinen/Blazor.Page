using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Page
{
    public class BlazorPageInterop
    {
        public static void ChangeTitle(IJSRuntime jsRuntime, string newTitle)
        {
            jsRuntime.InvokeVoidAsync("blazorPageFunctions.changePageTitle", newTitle);
        }

        public static async ValueTask<string> GetTitle(IJSRuntime jsRuntime)
        {
            return await jsRuntime.InvokeAsync<string>("blazorPageFunctions.getTitle");
        }
    }
}
