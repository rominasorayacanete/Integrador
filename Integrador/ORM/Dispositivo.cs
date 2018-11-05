namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dispositivo")]
    public partial class Dispositivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dispositivo()
        {
            Actuador = new HashSet<Actuador>();
        }

        public int id { get; set; }

        public int? cliente_id { get; set; }

        [Required]
        [StringLength(15)]
        public string nombre_generico { get; set; }

        public int consumo_hora { get; set; }

        public bool encendido { get; set; }

        public bool? modo_ahorro_energia { get; set; }

        public int consumo { get; set; }

        public int? uso_mensual_max { get; set; }

        public int? uso_mensual_min { get; set; }

        public bool? inteligente { get; set; }

        [StringLength(15)]
        public string tipo_dispositivo { get; set; }

        public int? uso_estimado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actuador> Actuador { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
