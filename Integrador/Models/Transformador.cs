using System;

namespace Integrador.Models
{
    public class Transformador
    {
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public float EnergiaSuministrada { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public Zona_Geografica ZonaGeografica { get; set; }
    }
}

