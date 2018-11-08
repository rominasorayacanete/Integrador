using System;

namespace Integrador.Models
{
    public class Administrador : Usuario
    {
        private int IdSistema { get; set; }

        public int MesesComoAdministrador() => Math.Abs((DateTime.Now.Month - FechaAltaSistema.Month) + 12 * (DateTime.Now.Year - FechaAltaSistema.Year));       
    }
}