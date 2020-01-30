using HomelessHelper.Model;
using HomelessHelper.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HomelessHelper.ViewModel
{
    public class CityViewModel:BaseViewModel
    {
        private string cityName;
        private string helpType;
        public ICommand BrowseCommand { get; private set; }
        public ICommand CallCommand { get; private set; }
        private ObservableCollection<Organization> organizations;
        public ObservableCollection<Organization> Organizations
        {
            get { return organizations; }
            set
            {
                organizations = value;
                NotifyPropertyChanged("Organizations");
            }
        }
        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                NotifyPropertyChanged("CityName");
            }
        }
        public string HelpType
        {
            get { return helpType; }
            set
            {
                helpType = value;
                NotifyPropertyChanged("HelpType");
            }
        }
        public CityViewModel()
        {
            BrowseCommand = new Command(async (site) => await BrowseCommandExecute(site.ToString()));
            CallCommand = new Command((number) =>  CallCommandExecute(number.ToString()));
            string cty = BaseViewModel.City;
            CityName = cty;
            string type = BaseViewModel.Type.ToString();
            HelpType = type;
            var orgs = new ObservableCollection<Organization>();
            foreach(var x in FetchOrganizationDataService.Organizations)
            {
                if (x.City == cty && x.Type == type)
                    orgs.Add(x);
            }
            organizations = orgs;
        }
        public async Task BrowseCommandExecute(string site)
        {
            await Browser.OpenAsync(site, BrowserLaunchMode.SystemPreferred);
        }
        public void CallCommandExecute(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch(Exception e)
            {
                Console.WriteLine("Phone Call error"+e);
            }
        }
    }
}
