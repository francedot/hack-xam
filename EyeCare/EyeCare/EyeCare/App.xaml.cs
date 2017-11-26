using EyeCare.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EyeCare
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new CameraPage());
		}
	}
}