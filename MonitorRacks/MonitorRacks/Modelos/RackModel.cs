using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorRacks.Modelos
{
    public class RackModel
    {
        public bool Energia { get; set; }
        public int Humedad { get; set; }
        public bool Luz { get; set; }
        public bool Puertas { get; set; }
        public int Temperatura { get; set; }
    }
}
