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

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        [Required]
        [StringLength(25)]
        public string apellido { get; set; }

        [Required]
        [StringLength(15)]
        public string tipo_doc { get; set; }

        public int nro_doc { get; set; }

        [StringLength(30)]
        public string domicilio { get; set; }

        public int? puntos { get; set; }

        public int? telefono { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? longitud { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? latitud { get; set; }

        public int? zona_id { get; set; }

        public int? categoria_id { get; set; }

        [StringLength(15)]
        public string usuario { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual Zona_Geografica Zona_Geografica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dispositivo> Dispositivo { get; set; }
    }
}
