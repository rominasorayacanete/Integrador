namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Template_Dispositivo
    {
        [Key]
        public int temp_id { get; set; }

        [StringLength(255)]
        public string temp_nombre { get; set; }

        public bool? temp_inteligente { get; set; }

        public bool? temp_bajo_consumo { get; set; }

        public int? temp_consumo { get; set; }

        public int? temp_dispositivo { get; set; }
    }
}
