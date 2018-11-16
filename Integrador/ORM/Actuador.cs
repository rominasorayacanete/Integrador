namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actuador")]
    public partial class Actuador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actuador()
        {
            Regla = new HashSet<Regla>();
        }

        [Key]
        public int actu_id { get; set; }

        [StringLength(255)]
        public string actu_accion { get; set; }

        public int? actu_dispositivo { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regla> Regla { get; set; }
    }
}
