using HomelessHelper.Model;
using HomelessHelper.Services;
using HomelessHelper.View;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomelessHelper.ViewModel
{
    public class MenuViewModel:BaseViewModel
    {
        public ICommand FindShelterCommand { get; private set; }
        public ICommand FindContributeCommand { get; private set; }
        public ICommand FindHealthcareCommand { get; private set; }
        public ICommand NavigateToContactCommand { get; private set; }
        public MenuViewModel()
        {
            FindShelterCommand = new Command(async () => await FindShelterCommandExecute());
            FindContributeCommand = new Command(async () => await FindContributeCommandExecute());
            FindHealthcareCommand = new Command(async () => await FindHealthcareCommandExecute());
            NavigateToContactCommand = new Command(async () => await NavigateToContactCommandExecute());
        }
        private async Task FindShelterCommandExecute()
        {
            BaseViewModel.Type = OrganizationType.Shelter;
            await NavigationService.NavigateToAsync(new ListCities());
        }
        private async Task FindContributeCommandExecute()
        {
            BaseViewModel.Type = OrganizationType.Contribute;
            await NavigationService.NavigateToAsync(new ListCities());
        }
        private async Task FindHealthcareCommandExecute()
        {
            BaseViewModel.Type = OrganizationType.HealthCare;
            await NavigationService.NavigateToAsync(new ListCities());
        }
        private async Task NavigateToContactCommandExecute()
        {
            await NavigationService.NavigateToAsync(new Contact());
        }
    }
}
