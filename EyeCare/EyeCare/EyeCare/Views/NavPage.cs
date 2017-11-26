using EyeCare.Helpers;
using Xamarin.Forms;

namespace EyeCare.Views
{
    public class NavPage : ContentPage
    {
        protected virtual INavigationAware ViewModel =>
            this.BindingContext as INavigationAware;

        protected NavPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnNavigatedFromAsync();

            ViewModel.Navigation = Navigation;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ViewModel.OnNavigatedFromAsync();

            ViewModel.Navigation = default(INavigation);
        }
    }
}