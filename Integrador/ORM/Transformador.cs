namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transformador")]
    public partial class Transformador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transformador()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string nombre { get; set; }

        public bool activo { get; set; }

        public double energia_suministrada { get; set; }

        public double latitud { get; set; }

        public double longitud { get; set; }

        public int? zona_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        public virtual Zona_Geografica Zona_Geografica { get; set; }
    }
}
