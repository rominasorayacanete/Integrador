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

        public int id { get; set; }

        public bool? regla_cumplida { get; set; }

        [StringLength(250)]
        public string condicion { get; set; }

        public int? sensor { get; set; }

        public virtual Sensor Sensor1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actuador> Actuador { get; set; }
    }
}
