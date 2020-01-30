using HomelessHelper.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomelessHelper.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Loading : ContentPage
	{
		public Loading ()
		{
			InitializeComponent ();
			BindingContext = new LoadingViewModel();
		}
	}
}