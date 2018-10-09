namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoDispositivo")]
    public partial class TipoDispositivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoDispositivo()
        {
            Actuador = new HashSet<Actuador>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTipoDispositivo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Consumo { get; set; }

        public int? UsoMensualMax { get; set; }

        public int? UsoMensualMin { get; set; }

        [StringLength(30)]
        public string EquipoConcreto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actuador> Actuador { get; set; }
    }
}
