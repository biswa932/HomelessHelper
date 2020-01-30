using HomelessHelper.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomelessHelper.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListCities : ContentPage
	{
		public ListCities ()
		{
			InitializeComponent ();
			BindingContext = new ListCitiesViewModel();
			((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("332F2E");
		}
	}
}