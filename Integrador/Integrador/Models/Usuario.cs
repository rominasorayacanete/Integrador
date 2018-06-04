using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Usuario
    {
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string tipoDocumento { get; set; }
        private string domicilio { get; set; }
        private string nombreUsuario { get; set; }
        private string contrasenia { get; set; }
        private int nroDocumento { get; set; }
        private int telefono { get; set; }
    }
}
