using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Page
{
    public abstract class Page<TPageModel> : Page where TPageModel : PageModelBase
    {
        private TPageModel _dataContext;

        [Inject] public TPageModel DataContext
        {
            get
            {
                return _dataContext;
            }

            set
            {
                _dataContext = value;
                if (_dataContext == null)
                {
                    return;
                }

                _dataContext.Parent = this;
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (!firstRender)
            {
                return;
            }

            DataContext.OnActivated();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                return Task.CompletedTask;
            }

            return DataContext.OnActivatedAsync();
        }

        protected override void OnInitialized()
        {
            DataContext.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return DataContext.OnInitializedAsync();
        }
    }

    public abstract class Page : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public string Title
        {
            set
            {
                SetTitle(value);
            }
        }

        public void SetTitle(string newTitle)
        {
            BlazorPageInterop.ChangeTitle(JSRuntime, newTitle);
        }

        public async ValueTask<string> GetTitle()
        {
            return await BlazorPageInterop.GetTitle(JSRuntime);
        }
    }
}
