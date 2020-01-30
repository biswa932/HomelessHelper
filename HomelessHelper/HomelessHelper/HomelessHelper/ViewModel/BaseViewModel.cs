using HomelessHelper.Model;
using System.ComponentModel;

namespace HomelessHelper.ViewModel
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public static string City { get; set; }
        public static OrganizationType Type { get; set; }
        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
