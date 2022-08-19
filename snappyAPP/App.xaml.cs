using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using snappyAPP.Views;

namespace snappyAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Presentacion();
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
