namespace Integrador.Migrations
{
    using Integrador.Models;
    using Integrador.Models.Clases;
    using Integrador.Services;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Integrador.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Integrador.DAL.Context";
        }

        protected override void Seed(Integrador.DAL.Context context)
        {
            context.Usuarios.AddOrUpdate();

            // Set Services
            OperacionService operacionService = new OperacionService();


            // Set Categorias
            List<Categoria> categorias = new List<Categoria>();
            Categoria categoria1 = new Categoria {Nombre = "R1", ConsumoMaximo = 150, CargoFijo = 18.76, CargoVariable = 0.644};
            Categoria categoria2 = new Categoria {Nombre = "R2", ConsumoMinimo = 150 , ConsumoMaximo = 325, CargoFijo = 35.32, CargoVariable = 0.644};
            Categoria categoria3 = new Categoria {Nombre = "R3", ConsumoMinimo = 325 , ConsumoMaximo = 400, CargoFijo = 60.71, CargoVariable = 0.681};
            Categoria categoria4 = new Categoria {Nombre = "R4", ConsumoMinimo = 400 , ConsumoMaximo = 450, CargoFijo = 71.74, CargoVariable = 0.724};
            Categoria categoria5 = new Categoria {Nombre = "R5", ConsumoMinimo = 450 , ConsumoMaximo = 500, CargoFijo = 110.38, CargoVariable = 0.789};
            Categoria categoria6 = new Categoria {Nombre = "R6", ConsumoMinimo = 500 , ConsumoMaximo = 600, CargoFijo = 220.24, CargoVariable = 0.802};
            Categoria categoria7 = new Categoria {Nombre = "R7", ConsumoMinimo = 600, CargoFijo = 443.16, CargoVariable = 0.841 };

            categorias.Add(categoria1);
            categorias.Add(categoria2);
            categorias.Add(categoria3);
            categorias.Add(categoria4);
            categorias.Add(categoria5);
            categorias.Add(categoria6);
            categorias.Add(categoria7);
            categorias.ForEach(c => context.Categorias.Add(c));

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

            List<Usuario> usuarios = this.getUsuarios(context);
            var usuarioAdmin = usuarios[0];
            var usuarioCliente = usuarios[1];

            // Set Marcas


            // Set Dispositivos

            List<Dispositivo> dispositivos = new List<Dispositivo>();

            DispositivoInteligente d1 = new DispositivoInteligente
            {
                NombreGenerico = "Smart 200",
                Tipo = "Aire Acondicionado",
                Consumo = 200,
                UsoMensualMax = 2000,
                UsoMensualMin = 200,
                Encendido = true,
                ModoAhorroDeEnergia = true,
            };
            DispositivoEstandar d2 = new DispositivoEstandar
            {
                NombreGenerico = "No smart w3003",
                Tipo = "Heladera",
                Consumo = 100,
                UsoMensualMax = 1000,
                UsoMensualMin = 100,
            };

            ModuloAdaptador adaptador = new ModuloAdaptador();

            DispositivoEstandar d3 = new DispositivoEstandar
            {
                NombreGenerico = "Ultra Led",
                Tipo = "Lampara",
                Consumo = 50,
                UsoMensualMax = 500,
                UsoMensualMin = 120,
                ModuloAdaptador = adaptador,
            };

            dispositivos.Add(d1);
            dispositivos.Add(d2);

            dispositivos.ForEach(d => context.Dispositivos.Add(d));

            // Set Administrador

             Administrador admin = new Administrador { IdSistema = "100SSB", Usuario = usuarioAdmin, Nombre = "Juan" , Apellido = "Solo", Domicilio = "Rivadavia 9889", FechaAlta = DateTime.Now };
            context.Administradores.Add(admin);

            // Set Cliente
            Cliente cliente = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Gonzalez",
                TipoDoc = "DNI",
                NroDoc = 10101010,
                Telefono = 12345678,
                Puntos = 11,
                Dispositivos = dispositivos,
                Transformador = t1,
                Usuario = usuarioCliente
            };

            context.Clientes.Add(cliente);

            context.SaveChanges();

        }

        private List<Usuario> getUsuarios(Integrador.DAL.Context context)
        {
            List<Usuario> usuarios = new List<Usuario>();

            var admin = context.Usuarios
                .Where(u => u.Username == "admin1")
                .FirstOrDefault();

            if (admin == null)
            {
                admin = new Usuario { Username = "admin1", Password = "admin1", Email = "admin@admin.com", FechaAltaSistema = DateTime.Now };
                context.Usuarios.Add(admin);
            }

            var cliente = context.Usuarios
                .Where(u => u.Username == "cliente1")
                .FirstOrDefault();

            if (cliente == null)
            {
                cliente = new Usuario { Username = "cliente1", Password = "cliente1", Email = "cliente@cliente.com", FechaAltaSistema = DateTime.Now };
                context.Usuarios.Add(cliente);
            }

            usuarios.Add(admin);
            usuarios.Add(cliente);

            return usuarios;
        }
    }
}
