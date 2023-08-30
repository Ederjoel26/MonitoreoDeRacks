using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.CloudFirestore;
using Xamarin.Essentials;

namespace MonitorRacks.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IniciarSesion : ContentPage
    {
        private double sAncho = 0;
        private double sAlto = 0;

        public IniciarSesion()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ActualizarOrientacion();
        }

        protected override void OnSizeAllocated(double sAncho, double sAlto)
        {
            base.OnSizeAllocated(sAncho, sAncho);

            if (this.sAncho != sAncho || this.sAlto != sAlto)
            {
                this.sAncho = sAncho;
                this.sAlto = sAlto;

                ActualizarOrientacion();
            }
        }

        private async void Button_IniciarSesion(object sender, EventArgs e)
        {
            await AnimationButtonClicked(sAlto > sAncho ? btnIniciarSesionV : btnIniciarSesionH);

            string sUsuario = sAlto > sAncho
                ? txtUsuarioV.Text
                : txtUsuarioH.Text;

            string sPassword = sAlto > sAncho
                ? txtPasswordV.Text
                : txtPasswordH.Text;

            if (sUsuario == "test" && sPassword == "test")
            {
                //Navegar al menú
                await Navigation.PushModalAsync(new Menu());
            }
            else
            {
                await DisplayAlert("Acceso Denegado", "Usuario no autentificado.", "OK");
            }
        }

        private async void Button_Huella(object sender, EventArgs e)
        {
            await AnimationButtonClicked(sAlto > sAncho ? btnHuellaV : btnHuellaH);

            if (await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync(
                   new AuthenticationRequestConfiguration("Iniciar Sesión", "Acceder a la aplicación"));
                if (result.Authenticated)
                {
                    //Navegar al menú
                    await Navigation.PushModalAsync(new Menu());
                }
                else
                {
                    await DisplayAlert("Acceso Denegado", "Usuario no autentificado.", "OK");
                }
            }
            else
            {
                await DisplayAlert("No disponible", "Sensor de huella no disponible.", "OK");
            }
        }

        private async Task AnimationButtonClicked(Button Btn)
        {
            await Btn.ScaleTo(0.95, 50, Easing.CubicOut);
            await Btn.ScaleTo(1, 50, Easing.CubicIn);
        }

        private void ActualizarOrientacion()
        {
            if (sAlto > sAncho)
            {
                gdVertical.IsVisible = true;
                gdHorizontal.IsVisible = false;
            }
            else
            {
                gdHorizontal.IsVisible = true;
                gdVertical.IsVisible = false;
            }
        }
    }
}