using System.Threading.Tasks;

namespace Blazor.Page
{
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
