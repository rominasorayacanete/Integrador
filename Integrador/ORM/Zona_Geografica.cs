namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Zona_Geografica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zona_Geografica()
        {
            Cliente = new HashSet<Cliente>();
            Transformador = new HashSet<Transformador>();
        }

        [Key]
        public int zona_id { get; set; }

        public int? zona_radio { get; set; }

        public double? zona_longitud { get; set; }

        public double? zona_latitud { get; set; }

        [StringLength(255)]
        public string zona_nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transformador> Transformador { get; set; }
    }
}
