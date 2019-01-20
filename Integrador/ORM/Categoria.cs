namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        public double? consumo_minimo { get; set; }

        public double? consumo_maximo { get; set; }

        public double cargo_fijo { get; set; }

        public double cargo_variable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
