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
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }
        public bool activo { get; set; }
        public float energia_suministrada { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        
        [ForeignKey("Zona_Geografica")]
        public int zona_id { get; set; }
    }
}
