using MonitorRacks.Modelos;
using MonitorRacks.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorRacks.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiteElemento : ContentView
    {
        public static readonly BindableProperty imgPuertaWidthProperty = BindableProperty.Create(nameof(imgPuertaWidth), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty imgPuertaHeightProperty = BindableProperty.Create(nameof(imgPuertaHeight), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty lblPuertaProperty = BindableProperty.Create(nameof(lblPuerta), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty gTemperaturaWidthProperty = BindableProperty.Create(nameof(gTemperaturaWidth), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty gTemperaturaHeightProperty = BindableProperty.Create(nameof(gTemperaturaHeight), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty imgEnergiaWidthProperty = BindableProperty.Create(nameof(imgEnergiaWidth), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty imgEnergiaHeightProperty = BindableProperty.Create(nameof(imgEnergiaHeight), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty lblEnergiaProperty = BindableProperty.Create(nameof(lblEnergia), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty imgLuzWidthProperty = BindableProperty.Create(nameof(imgLuzWidth), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty imgLuzHeightProperty = BindableProperty.Create(nameof(imgLuzHeight), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty lblLuzProperty = BindableProperty.Create(nameof(lblLuz), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty gHumedadWidthProperty = BindableProperty.Create(nameof(gHumedadWidth), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty gHumedadHeightProperty = BindableProperty.Create(nameof(gHumedadHeight), typeof(int), typeof(SiteElemento), 75);
        public static readonly BindableProperty imgPuertaSourceProperty = BindableProperty.Create(nameof(imgPuertaSource), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty imgLuzSourceProperty = BindableProperty.Create(nameof(imgLuzSource), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty imgEnergiaSourceProperty = BindableProperty.Create(nameof(imgEnergiaSource), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty currentTemperaturaProperty = BindableProperty.Create(nameof(currentTemperatura), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty currentHumedadProperty = BindableProperty.Create(nameof(currentHumedad), typeof(string), typeof(SiteElemento));
        public static readonly BindableProperty lblSizeTemperaturaProperty = BindableProperty.Create(nameof(lblSizeTemperatura), typeof(int), typeof(SiteElemento));
        public static readonly BindableProperty lblSizeHumedadProperty = BindableProperty.Create(nameof(lblSizeHumedad), typeof(int), typeof(SiteElemento));
        public static readonly BindableProperty lblSizeEnergiaProperty = BindableProperty.Create(nameof(lblSizeEnergia), typeof(int), typeof(SiteElemento));
        public static readonly BindableProperty lblSizeLuzProperty = BindableProperty.Create(nameof(lblSizeLuz), typeof(int), typeof(SiteElemento));
        public static readonly BindableProperty lblSizePuertaProperty = BindableProperty.Create(nameof(lblSizePuerta), typeof(int), typeof(SiteElemento));

        public int lblSizeTemperatura
        {
            get => (int)GetValue(lblSizeTemperaturaProperty);
            set => SetValue(lblSizeTemperaturaProperty, value);
        }

        public int lblSizeHumedad
        {
            get => (int)GetValue(lblSizeHumedadProperty);
            set => SetValue(lblSizeHumedadProperty, value);
        } 

        public int lblSizeEnergia
        {
            get => (int)GetValue(lblSizeEnergiaProperty);
            set => SetValue(lblSizeEnergiaProperty, value);
        }

        public int lblSizeLuz
        {
            get => (int)GetValue(lblSizeLuzProperty);
            set => SetValue(lblSizeLuzProperty, value);
        }

        public int lblSizePuerta
        {
            get => (int)GetValue(lblSizePuertaProperty);
            set => SetValue(lblSizePuertaProperty, value); 
        }

        public string currentTemperatura
        {
            get => (string)GetValue(currentTemperaturaProperty);
            set => SetValue(currentTemperaturaProperty, value);
        }

        public string currentHumedad
        {
            get => (string)GetValue(currentHumedadProperty);
            set => SetValue(currentHumedadProperty, value);
        }

        public string imgEnergiaSource
        {
            get => (string)GetValue(imgEnergiaSourceProperty);
            set => SetValue(imgEnergiaSourceProperty, value);
        }

        public string imgLuzSource
        {
            get => (string)GetValue(imgLuzSourceProperty);
            set => SetValue(imgLuzSourceProperty, value);
        }

        public string imgPuertaSource
        {
            get => (string)GetValue(imgPuertaSourceProperty);
            set => SetValue(imgPuertaSourceProperty, value);
        }

        public int imgPuertaWidth
        {
            get => (int)GetValue(imgPuertaWidthProperty);
            set => SetValue(imgPuertaWidthProperty, value);
        }

        public int imgPuertaHeight
        {
            get => (int)GetValue(imgPuertaHeightProperty);
            set => SetValue(imgPuertaHeightProperty, value);
        }

        public string lblPuerta
        {
            get => (string)GetValue(lblPuertaProperty);
            set => SetValue(lblPuertaProperty, value);
        }

        public int gTemperaturaWidth
        {
            get => (int)GetValue(gTemperaturaWidthProperty);
            set => SetValue(gTemperaturaWidthProperty, value);
        }

        public int gTemperaturaHeight
        {
            get => (int)GetValue(gTemperaturaHeightProperty);
            set => SetValue(gTemperaturaHeightProperty, value);
        }

        public int imgEnergiaWidth
        {
            get => (int)GetValue(imgEnergiaWidthProperty);
            set => SetValue(imgEnergiaWidthProperty, value);
        }

        public int imgEnergiaHeight
        {
            get => (int)GetValue(imgEnergiaHeightProperty);
            set => SetValue(imgEnergiaHeightProperty, value);
        }

        public string lblEnergia
        {
            get => (string)GetValue(lblEnergiaProperty);
            set => SetValue(lblEnergiaProperty, value);
        }

        public int imgLuzWidth
        {
            get => (int)GetValue(imgLuzWidthProperty);
            set => SetValue(imgLuzWidthProperty, value);
        }

        public int imgLuzHeight
        {
            get => (int)GetValue(imgLuzHeightProperty);
            set => SetValue(imgLuzHeightProperty, value);
        }

        public string lblLuz
        {
            get => (string)GetValue(lblLuzProperty);
            set => SetValue(lblLuzProperty, value);
        }

        public int gHumedadWidth
        {
            get => (int)GetValue(gHumedadWidthProperty);
            set => SetValue(gHumedadWidthProperty, value);
        }

        public int gHumedadHeight
        {
            get => (int)GetValue(gHumedadHeightProperty);
            set => SetValue(gHumedadHeightProperty, value);
        }

        private int _IdSite { get; set; }
        private int _IdRack { get; set; }
        private RackModel _Rack { get; set; }

        public SiteElemento(int idRack, int idSite)
        {
            InitializeComponent();
            gaugeTemperatura.FromColor = Color.Blue;
            gaugeTemperatura.ToColor = Color.Red;
            gaugeHumedad.ViaColor = Color.Blue;
            _IdRack = idRack;
            _IdSite = idSite;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await fContenedor.ScaleTo(0.95, 50, Easing.CubicOut);
            await fContenedor.ScaleTo(1, 50, Easing.CubicIn);

            await Navigation.PushAsync(new Rack(_IdRack, _IdSite));
        }
    }
}