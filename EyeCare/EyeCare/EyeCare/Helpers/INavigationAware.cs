using System.Threading.Tasks;
using Xamarin.Forms;

namespace EyeCare.Helpers
{
    public interface INavigationAware
    {
        INavigation Navigation { get; set; }

        Task OnNavigatedToAsync();
        Task OnNavigatedFromAsync();
    }
}