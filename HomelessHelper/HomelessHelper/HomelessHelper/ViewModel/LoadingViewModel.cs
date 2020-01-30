using HomelessHelper.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace HomelessHelper.ViewModel
{
    public class LoadingViewModel:BaseViewModel
    {
        private bool isActivityIndicatorRunning;
        private bool isRetryVisible;
        public ICommand RetryCommand { get; private set; }
        public bool IsRetryVisible
        {
            get { return isRetryVisible; }
            set
            {
                isRetryVisible = value;
                NotifyPropertyChanged("IsRetryVisible");
            }
        }
        public bool IsActivityIndicatorRunning
        {
            get { return isActivityIndicatorRunning; }
            set
            {
                isActivityIndicatorRunning = value;
                NotifyPropertyChanged("IsActivityIndicatorRunning");
            }
        }
        public LoadingViewModel()
        {
            IsRetryVisible = false;
            IsActivityIndicatorRunning = true;
            Task t = GetAllData();
            RetryCommand = new Command(async () => await RetryCommandExecute());
        }
        private async Task GetAllData()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                var data = await FetchOrganizationDataService.GetOrganizationDataAsync();
                if (data != null)
                {
                    FetchOrganizationDataService.Organizations = data;
                    IsActivityIndicatorRunning = false;
                    IsRetryVisible = true;
                    NavigationService.ReInitialize(new HomelessHelper.View.Menu());
                    
                }
                else
                {
                    IsActivityIndicatorRunning = false;
                    IsRetryVisible = true;
                }
            }
            else
            {
                IsActivityIndicatorRunning = false;
                IsRetryVisible = true;
            }
            
        }

        private async Task RetryCommandExecute()
        {
            IsRetryVisible = false;
            IsActivityIndicatorRunning = true;
            await GetAllData();
        }
    }
}
