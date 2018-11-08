using System;

namespace Integrador.Models
{
    public class Usuario
    {
        protected string Username { get; set; }
        protected string Password { get; set; }
        protected string Nombre { get; set; }
        protected string Apellido { get; set; }
        protected string Tipo_documento { get; set; }
        protected int Nro_documento { get; set; }
        protected DateTime FechaAltaSistema { get; set; }
        protected string Domicilio { get; set; }
        protected int Telefono { get; set; }
    }
}
