using HomelessHelper.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomelessHelper.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class City : ContentPage
	{
		public City ()
		{
			InitializeComponent ();
			BindingContext = new CityViewModel();
		}
	}
}