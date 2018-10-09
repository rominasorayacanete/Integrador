namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DispositivoInteligente")]
    public partial class DispositivoInteligente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDispositivoInteligente { get; set; }

        public bool? Encendido { get; set; }

        public bool? ModoAhorroDeEnergia { get; set; }
    }
}
