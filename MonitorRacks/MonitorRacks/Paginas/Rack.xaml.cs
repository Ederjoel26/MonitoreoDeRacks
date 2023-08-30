using MonitorRacks.Modelos;
using MonitorRacks.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorRacks.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rack : ContentPage
    {
        private int _IdSite { get; set; }
        private int _IdRack { get; set; }  
        private RackModel _oRack { get; set; }
        private double sAncho = 0;
        private double sAlto = 0;
        private int iCounter = 0;
        public Rack(int idRack, int idSite)
        {
            InitializeComponent();
            _IdRack = idRack;
            _IdSite = idSite;
            _oRack = new RackModel();
        }

        protected override void OnSizeAllocated(double sAncho, double sAlto)
        {
            base.OnSizeAllocated(sAncho, sAncho);

            if (this.sAncho != sAncho || this.sAlto != sAlto)
            {
                this.sAncho = sAncho;
                this.sAlto = sAlto;

                iCounter++;
                
                if(iCounter == 1)
                {
                    ConsultarBD.ConsultarRackRealTIme(_IdSite, _IdRack, _oRack, ActualizarOrientacion);
                }
                
                if(_oRack != null)
                {
                    ActualizarOrientacion(_oRack);
                }
            }
        }

        private void ActualizarOrientacion(RackModel _oRack)
        {
            if (sAlto > sAncho)
            {
                gdVertical.IsVisible = true;
                gdHorizontal.IsVisible = false;
                imgPuertaV.Source = _oRack.Puertas ? "puerta_abierta.png" : "puerta_cerrada.png";
                lblPuertaV.Text = _oRack.Puertas ? "Abierta" : "Cerrada";
                imgLuzV.Source = _oRack.Luz ? "foco_encendido.png" : "foco_apagado.png";
                lblLuzV.Text = _oRack.Luz ? "Encendida" : "Apagada";
                imgEnergiaV.Source = _oRack.Energia ? "no_energia.png" : "energia.png";
                lblEnergiaV.Text = _oRack.Energia ? "Hay Energia" : "No Hay Energia";
                gaugeHumedadV.CurrentValue = _oRack.Humedad;
                lblHumedadV.Text = "Humedad";
                gaugeHumedadV.WidthRequest = 200;
                gaugeHumedadV.HeightRequest = 200;
                gaugeTemperaturaV.CurrentValue = _oRack.Temperatura;
                lblTemperaturaV.Text = "Temperatura";
                gaugeTemperaturaV.WidthRequest = 200;
                gaugeTemperaturaV.HeightRequest = 200;
                gaugeTemperaturaV.FromColor = Color.Blue;
                gaugeTemperaturaV.ToColor = Color.Red;
                gaugeHumedadV.ViaColor = Color.Blue;
            }
            else
            {
                gdHorizontal.IsVisible = true;
                gdVertical.IsVisible = false;
                imgPuertaH.Source = _oRack.Puertas ? "puerta_abierta.png" : "puerta_cerrada.png";
                lblPuertaH.Text = _oRack.Puertas ? "Abierta" : "Cerrada";
                imgLuzH.Source = _oRack.Luz ? "foco_encendido.png" : "foco_apagado.png";
                lblLuzH.Text = _oRack.Luz ? "Encendida" : "Apagada";
                imgEnergiaH.Source = _oRack.Energia ? "no_energia.png" : "energia.png";
                lblEnergiaH.Text = _oRack.Energia ? "Hay Energia" : "No Hay Energia";
                gaugeHumedadH.CurrentValue = _oRack.Humedad;
                lblHumedadH.Text = "Humedad";
                gaugeHumedadH.WidthRequest = 200;
                gaugeHumedadH.HeightRequest = 200;
                gaugeTemperaturaH.CurrentValue = _oRack.Temperatura;
                lblTemperaturaH.Text = "Temperatura";
                gaugeTemperaturaH.WidthRequest = 200;
                gaugeTemperaturaH.HeightRequest = 200;
                gaugeTemperaturaH.FromColor = Color.Blue;
                gaugeTemperaturaH.ToColor = Color.Red;
                gaugeHumedadH.ViaColor = Color.Blue;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string sTitulo = string.Empty;

            if(_IdSite == 1)
            {
                sTitulo = "Arana";
            }else if(_IdSite == 2)
            {
                sTitulo = "Huertas";
            }else if(_IdSite == 3)
            {
                sTitulo = "Fresas";
            }

            Title = sTitulo + " - Rack " + _IdRack.ToString();

            if (_oRack != null)
            {
                ActualizarOrientacion(_oRack);
            }

        }
    }
}