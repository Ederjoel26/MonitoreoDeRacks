using MonitorRacks.Paginas;
using MonitorRacks.Utilidades;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorRacks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new IniciarSesion();
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
