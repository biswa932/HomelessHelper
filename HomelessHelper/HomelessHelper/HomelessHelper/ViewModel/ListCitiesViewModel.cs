using HomelessHelper.Model;
using HomelessHelper.Services;
using HomelessHelper.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomelessHelper.ViewModel
{
    public class ListCitiesViewModel:BaseViewModel
    {
        private string serviceType;
        private ObservableCollection<string> cities;
        public ICommand SearchCommand { get; private set; }
        public ObservableCollection<string> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                NotifyPropertyChanged("Cities");
            }
        }
        public string ServiceType
        {
            get { return serviceType; }
            set
            {
                serviceType = value;
                NotifyPropertyChanged("ServiceType");
            }
        }
        public ListCitiesViewModel()
        {
            SearchCommand = new Command(async (city) => await NavigateToCity(city.ToString()));
            var ctys = new ObservableCollection<string>();
            switch (BaseViewModel.Type)
            {
                case OrganizationType.Contribute:
                    ServiceType = "CityContribute";
                    break;

                case OrganizationType.HealthCare:
                    ServiceType = "CityHealthCare";
                    break;

                case OrganizationType.Shelter:
                    ServiceType = "CityShelter";
                    break;
            }
            foreach(var x in FetchOrganizationDataService.Organizations)
            {
                var type = BaseViewModel.Type;
                if (x.Type == type.ToString() && !ctys.Contains(x.City))
                {
                    ctys.Add(x.City);
                }
            }
            cities = ctys;
        }
        public async Task NavigateToCity(string city)
        {
            BaseViewModel.City = city;
            await NavigationService.NavigateToAsync(new City());
        }
    }
}
