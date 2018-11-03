namespace Integrador.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zona_Geografica")]
    public partial class ZonaGeografica
    {
        public int id { get; set; }
        public int radio { get; set; }
        public string nombre_zona { get; set; }

        public ICollection<Transformador> transformadores { get; set; }
    }
}