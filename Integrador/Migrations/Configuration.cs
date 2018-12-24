namespace Integrador.Migrations
{
    using Integrador.Models;
    using Integrador.Models.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Integrador.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Integrador.DAL.Context";
        }

        protected override void Seed(Integrador.DAL.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Usuarios.AddOrUpdate();

            // Set ZonaGeografica
            List<ZonaGeografica> zonasGeograficas = new List<ZonaGeografica>();

            ZonaGeografica zonaNorte = new ZonaGeografica {NombreZona = "ZonaNorte", Radio = 20, Latitud = -34.560306, Longitud = -58.503978 };
            ZonaGeografica zonaSur = new ZonaGeografica {NombreZona = "ZonaSur" , Radio = 40, Latitud = -34.633405, Longitud = -58.433785 };

            zonasGeograficas.Add(zonaNorte);
            zonasGeograficas.Add(zonaSur);

            zonasGeograficas.ForEach(z => context.ZonaGeograficas.Add(z));

            // Set Transformadores

            List<Transformador> transformadores = new List<Transformador>();

            Transformador t1 = new Transformador { Nombre = "Lugano" , EnergiaSuministrada = 100 , Activo = true, ZonaGeografica = zonaSur, Latitud = -34.665169, Longitud = -58.486817 };
            Transformador t2 = new Transformador { Nombre = "Mataderos" , EnergiaSuministrada = 200, Activo = true, ZonaGeografica = zonaSur, Latitud = -34.649090, Longitud = -58.506350 };
            Transformador t3 = new Transformador { Nombre = "Olivos", EnergiaSuministrada = 1000, Activo = true , ZonaGeografica = zonaNorte , Latitud = -34.513614, Longitud = -58.496524 };
            Transformador t4 = new Transformador { Nombre = "Palermo", EnergiaSuministrada = 2000, Activo = true, ZonaGeografica = zonaNorte , Latitud = -34.571026, Longitud = -58.434270 };

            transformadores.Add(t1);
            transformadores.Add(t2);
            transformadores.Add(t3);
            transformadores.Add(t4);

            transformadores.ForEach(t => context.Transformadores.Add(t));

            // Set Usuarios
           
            // Set Administrador
           
            // Administrador admin = new Administrador { IdSistema = "100SSB", Usuario = userAdmin };
            //context.Administradores.Add(admin);
            // Set Cliente
            // Cliente cliente = new Cliente { Nombre = "Juan", Apellido = "Gonzalez" , TipoDoc = "DNI" , NroDoc = 10101010, Telefono = 12345678, Puntos = 0 };

            context.SaveChanges();

        }
    }
}
