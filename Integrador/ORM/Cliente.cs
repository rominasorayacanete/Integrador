namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Dispositivo = new HashSet<Dispositivo>();
        }

        [Key]
        public int clie_id { get; set; }

        public int? clie_puntos { get; set; }

        public double? clie_latitud { get; set; }

        public double? clie_longitud { get; set; }

        public int? clie_categoria { get; set; }

        public int? clie_zona { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Zona_Geografica Zona_Geografica { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dispositivo> Dispositivo { get; set; }
    }
}
