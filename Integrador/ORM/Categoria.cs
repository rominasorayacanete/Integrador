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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ConsumoMinimo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ConsumoMaximo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CargoFijo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CargoVariable { get; set; }
    }
}
