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
            Operacion = new HashSet<Operacion>();
        }

        [Key]
        public int disp_id { get; set; }

        public int? disp_cliente { get; set; }

        [StringLength(255)]
        public string disp_nombre_generico { get; set; }

        public int? disp_consumo_hora { get; set; }

        public bool? disp_encendido { get; set; }

        public bool? disp_modo_ahorro_energia { get; set; }

        public int? disp_consumo { get; set; }

        public int? disp_uso_mensual_max { get; set; }

        public int? disp_uso_mensual_min { get; set; }

        public bool? disp_inteligente { get; set; }

        [StringLength(255)]
        public string disp_tipo_dispositivo { get; set; }

        public int? disp_uso_estimado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actuador> Actuador { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
