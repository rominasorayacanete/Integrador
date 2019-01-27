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
            Transformador = new HashSet<Transformador>();
        }

        public int id { get; set; }

        public int radio { get; set; }

        public double? longitud { get; set; }

        public double? latitud { get; set; }

        [Required]
        [StringLength(15)]
        public string nombre_zona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transformador> Transformador { get; set; }
    }
}