using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
   
        public class ViewModelBase : BaseViewModel//, INotifyPropertyChanged
        {
            //DataService dataService;
            //public DataService DataService => dataService ??= DependencyService.Get<DataService>();


            public async Task<bool> CheckConnectivity(string title, string message)
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    return true;

                await DisplayAlert(title, message);
                return false;
            }

            public Task DisplayAlert(string title, string message) =>
                Application.Current.MainPage.DisplayAlert(title, message, "OK");
            public Task<bool> DisplayAlert(string title, string message, string accept, string cancel) =>
                Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);


            //protected bool SetProperty<T>(ref T backingStore, T value,
            //    [CallerMemberName]string propertyName = "",
            //    Action onChanged = null)
            //{
            //    if (EqualityComparer<T>.Default.Equals(backingStore, value))
            //        return false;

            //    backingStore = value;
            //    onChanged?.Invoke();
            //    OnPropertyChanged(propertyName);
            //    return true;
            //}

            //#region INotifyPropertyChanged
            //public event PropertyChangedEventHandler PropertyChanged;
            //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            //{
            //    var changed = PropertyChanged;
            //    if (changed == null)
            //        return;

            //    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
            //#endregion


            //public void RaiseIfPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
            //{
            //    if (EqualityComparer<T>.Default.Equals(property, value))
            //    {
            //        return;
            //    }
            //    property = value;
            //    OnPropertyChanged(propertyName);
            //}

        }
    }

