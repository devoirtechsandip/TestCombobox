using App1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ1OTQyQDMxMzgyZTMzMmUzMG1xTit2KzJDTkEwK2ErMFBSRUdvekFuZHNJckhHc0FRK0pwVzMvLzVDNk09");
            MainPage = new TestCombo();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
