using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomelessHelper.Services
{
    public class NavigationService
    {
        public static async Task NavigateToAsync(ContentPage page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public static async Task PopPageAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public static void ReInitialize(ContentPage page)
        {
            Application.Current.MainPage = new NavigationPage(page);
        }
    }
}
