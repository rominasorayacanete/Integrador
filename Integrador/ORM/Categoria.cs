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

        [Key]
        public int cate_id { get; set; }

        [StringLength(255)]
        public string cate_nombre { get; set; }

        public double? cate_consumo_minimo { get; set; }

        public double? cate_consumo_maximo { get; set; }

        public double? cate_cargo_fijo { get; set; }

        public double? cate_cargo_variable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
