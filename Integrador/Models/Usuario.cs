using System;

namespace Integrador.Models
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo_documento { get; set; }
        public int Nro_documento { get; set; }
        public DateTime FechaAltaSistema { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
    }
}
