namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Regla")]
    public partial class Regla
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regla()
        {
            Actuador = new HashSet<Actuador>();
        }

        [Key]
        public int regl_id { get; set; }

        public bool? regl_cumplida { get; set; }

        [StringLength(255)]
        public string regl_condicion { get; set; }

        public int? regl_sensor { get; set; }

        public virtual Sensor Sensor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actuador> Actuador { get; set; }
    }
}
