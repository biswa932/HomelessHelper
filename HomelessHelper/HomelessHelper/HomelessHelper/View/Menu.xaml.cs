using HomelessHelper.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomelessHelper.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent ();
			BindingContext = new MenuViewModel();
		}
	}
}