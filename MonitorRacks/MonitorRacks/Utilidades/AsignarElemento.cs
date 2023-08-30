using MonitorRacks.Controles;
using MonitorRacks.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonitorRacks.Utilidades
{
    public class AsignarElementos
    {
        public static List<SiteElemento> AsignarValoresSite(List<RackModel> Racks, int iSite)
        {
            List<SiteElemento> Sites = new List<SiteElemento>();

            for (int i = 0; i < Racks.Count; i++)
            {
                SiteElemento Site = new SiteElemento(i + 1, iSite)
                {
                    lblEnergia = Racks[i].Energia.ToString(),
                    lblLuz = Racks[i].Luz.ToString(),
                    lblPuerta = Racks[i].Puertas.ToString(),
                    currentHumedad = Racks[i].Humedad.ToString(),
                    currentTemperatura = Racks[i].Temperatura.ToString(),
                };

                int iTamanio = Device.Idiom == TargetIdiom.Tablet ? 125 : 75;

                Site.imgEnergiaHeight = iTamanio;
                Site.imgEnergiaWidth = iTamanio;
                Site.imgLuzHeight = iTamanio;
                Site.imgLuzWidth = iTamanio;
                Site.imgPuertaHeight = iTamanio;
                Site.imgPuertaWidth = iTamanio;
                Site.gTemperaturaWidth = iTamanio;
                Site.gTemperaturaHeight = iTamanio;
                Site.gHumedadHeight = iTamanio;
                Site.gHumedadWidth = iTamanio;

                Site.imgEnergiaSource = Racks[i].Energia ? "no_energia.png" : "energia.png";
                Site.imgLuzSource = Racks[i].Luz ? "foco_encendido.png" : "foco_apagado.png";
                Site.imgPuertaSource = Racks[i].Puertas ? "puerta_abierta.png" : "puerta_cerrada.png";
                Site.currentTemperatura = Racks[i].Temperatura.ToString();
                Site.currentHumedad = Racks[i].Humedad.ToString();

                Site.lblLuz = Racks[i].Luz ? "Encendido" : "Apagado";
                Site.lblEnergia = Racks[i].Energia ? "Hay Energia" : "No Hay Energia";
                Site.lblPuerta = Racks[i].Puertas ? "Abierta" : "Cerrada";

                Sites.Add(Site);
            }

            return Sites;
        }
    }
}
