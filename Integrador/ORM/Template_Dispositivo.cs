namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Template_Dispositivo
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        public bool inteligente { get; set; }

        public bool bajo_consumo { get; set; }

        public int consumo { get; set; }
    }
}
