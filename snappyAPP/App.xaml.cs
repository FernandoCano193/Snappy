using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using snappyAPP.Views;
using snappyAPP.Views.Intro;

namespace snappyAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CrearUsuario();
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
