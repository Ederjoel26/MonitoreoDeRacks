using MonitorRacks.Controles;
using MonitorRacks.Modelos;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorRacks.Utilidades
{
    public class ConsultarBD
    {
        public delegate void CargarVista();
        public delegate void ActualizarOrientacion(RackModel oRack);
        public static void RealTimeRack(int iSite, List<RackModel> lstRacks, List<SiteElemento> Sites, CargarVista cargarVista)
        {
            try
            {
                RackModel oRack = null;

                string Site = "Site" + iSite.ToString();

                CrossCloudFirestore
                    .Current
                    .Instance
                    .Collection(Site)
                    .AddSnapshotListener((snap, error) =>
                    {
                        var Documents = snap.Documents.ToList();

                        lstRacks.Clear();

                        for (int i = 0; i < Documents.Count; i++)
                        {
                            lstRacks.Add(Documents[i].ToObject<RackModel>());
                        }

                        // Llena la lista Sites en lugar de asignar una nueva instancia.
                        Sites.Clear();

                        Sites.AddRange(AsignarElementos.AsignarValoresSite(lstRacks, iSite));

                        cargarVista();
                    });
            }
            catch (Exception ex)
            {

            }
        }

        public static void ConsultarRackRealTIme(int iSite, int iRack, RackModel oRack, ActualizarOrientacion actualizarOrientacion)
        { 
            CrossCloudFirestore
                .Current
                .Instance
                .Collection("Site" + iSite)
                .Document("Rack" + iRack)
                .AddSnapshotListener((snap, error) =>
                {
                    RackModel oRackModel = snap.ToObject<RackModel>();
                    oRack.Humedad = oRackModel.Humedad;
                    oRack.Temperatura = oRackModel.Temperatura;
                    oRack.Energia = oRackModel.Energia;
                    oRack.Luz = oRackModel.Luz;
                    oRack.Puertas = oRackModel.Puertas;
                    actualizarOrientacion(oRack);
                });
        }
    }
}
