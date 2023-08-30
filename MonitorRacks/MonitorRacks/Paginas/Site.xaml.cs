using MonitorRacks.Controles;
using MonitorRacks.Modelos;
using MonitorRacks.Utilidades;
using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorRacks.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Site : ContentPage
    {
        public static readonly BindableProperty SiteIdProperty = BindableProperty.Create(nameof(SiteId), typeof(int), typeof(Site), default(int));

        public int SiteId
        {
            get => (int)GetValue(SiteIdProperty);
            set => SetValue(SiteIdProperty, value);
        }

        private double sAncho = 0;
        private double sAlto = 0;
        private List<RackModel> Racks { get; set; }
        List<SiteElemento> Sites { get; set; }

        public Site()
        {
            InitializeComponent();

            if (SiteId == 0)
            {
                SiteId = 1;
            }

            Racks = new List<RackModel>();
            Sites = new List<SiteElemento>();
        }

        protected override void OnSizeAllocated(double sAncho, double sAlto)
        {
            base.OnSizeAllocated(sAncho, sAncho);

            if (this.sAncho != sAncho || this.sAlto != sAlto)
            {
                this.sAncho = sAncho;
                this.sAlto = sAlto;

                ActualizarOrientacion();

                if(Sites.Count != 0)
                {
                    CargarVista();  
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() =>
            {
                // Código que se ejecutará después de que la página se haya renderizado
                ConsultarBD.RealTimeRack(SiteId, Racks, Sites, CargarVista);
            });

        }

        private void ActualizarOrientacion()
        {
            if (sAncho > sAlto)
            {
                gdHorizontal.IsVisible = true;
                gdVertical.IsVisible = false;
            }
            else
            {
                gdHorizontal.IsVisible = false;
                gdVertical.IsVisible = true;
            }
        }

        private void CargarVista()
        {

            if (Device.Idiom == TargetIdiom.Phone && sAncho > sAlto)
            {
                foreach (var Site in Sites)
                {
                    Site.lblSizePuerta = 10;
                    Site.lblSizeLuz = 10;
                    Site.lblSizeEnergia = 10;
                    Site.lblSizeTemperatura = 10;
                    Site.lblSizeHumedad = 10;
                }
            }else if(Device.Idiom == TargetIdiom.Phone && sAncho < sAlto)
            {
                foreach (var Site in Sites)
                {
                    Site.lblSizePuerta = 15;
                    Site.lblSizeLuz = 15;
                    Site.lblSizeEnergia = 15;
                    Site.lblSizeTemperatura = 15;
                    Site.lblSizeHumedad = 15;
                }
            }

            gdHorizontal.Children.Clear();
            gdVertical.Children.Clear();

            if (sAncho > sAlto)
            {
                gdHorizontal.Children.Add(Sites[0], 0, 0);
                gdHorizontal.Children.Add(Sites[1], 1, 0);
                gdHorizontal.Children.Add(Sites[2], 0, 1);
                gdHorizontal.Children.Add(Sites[3], 1, 1);
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    gdVertical.Children.Add(Sites[i - 1], 0, i - 1);
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}