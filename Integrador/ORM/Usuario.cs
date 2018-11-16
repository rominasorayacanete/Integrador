namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Cliente = new HashSet<Cliente>();
        }

        [Key]
        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string apellido { get; set; }

        [StringLength(5)]
        public string tipo_documento { get; set; }

        public int? nro_documento { get; set; }

        public DateTime? fecha_alta_sistema { get; set; }

        [StringLength(255)]
        public string domicilio { get; set; }

        public int? telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrador> Administrador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
