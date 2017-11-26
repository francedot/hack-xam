using System.Threading.Tasks;
using EyeCare.Helpers;
using Xamarin.Forms;

namespace EyeCare.PageViewModels
{
    public class NavPageViewModelBase : PageViewModelBase, INavigationAware
    {
        public INavigation Navigation { get; set; }

        public virtual Task OnNavigatedToAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedFromAsync()
        {
            return Task.CompletedTask;
        }
    }
}