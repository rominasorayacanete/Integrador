namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Template_Dispositivo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre_generico { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? consumo_hora { get; set; }

        public bool? encendido { get; set; }

        public bool? inteligente { get; set; }
    }
}
