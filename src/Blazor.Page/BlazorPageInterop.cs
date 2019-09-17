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

    public abstract class PageModelBase
    {
        public Page Parent { get; set; }

        public virtual void OnInitialized()
        {
        }

        public virtual Task OnInitializedAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void OnActivated()
        {
        }

        public virtual Task OnActivatedAsync()
        {
            return Task.CompletedTask;
        }

        public string Title
        {
            set
            {
              SetTitle(value);
            }
        }

        public void SetTitle(string newTitle)
        {
            if (Parent == null)
            {
                return;
            }

            Parent.SetTitle(newTitle);
        }

        public async ValueTask<string> GetTitle()
        {
            if (Parent == null)
            {
                return null;
            }

            return await Parent.GetTitle();
        }
    }
}
