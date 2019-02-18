namespace Integrador.Migrations
{
    using Integrador.Models;
    using Integrador.Models.Clases;
    using Integrador.Models.Clases.Acciones;
    using Integrador.Models.Interface;
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

            // ----- Set Services ----- 
            OperacionService operacionService = new OperacionService();

            // ----- Set Categorias ----- 

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

            // ----- Set ZonaGeografica ----- 

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
            var usuarioCliente1 = usuarios[1];
            var usuarioCliente2 = usuarios[2];


            // Set Dispositivos

            List<Dispositivo> dispositivos1 = new List<Dispositivo>();
            List<Dispositivo> dispositivos2 = new List<Dispositivo>();

            DispositivoInteligente d1 = new DispositivoInteligente
            {
                NombreGenerico = "Smart 200",
                Tipo = "Aire Acondicionado",
                Consumo = 0.15,
                UsoMensualMax = 360,
                UsoMensualMin = 30,
                Encendido = true,
                MarcaDispositivo = "LG",
                ModoAhorroDeEnergia = true,
            };
            DispositivoEstandar d2 = new DispositivoEstandar
            {
                NombreGenerico = "No smart w3003",
                Tipo = "Heladera",
                Consumo = 0.0850,
                MarcaDispositivo = "Sony",
                UsoMensualMax = 1000,
                UsoMensualMin = 100,
            };

            ModuloAdaptador adaptador = new ModuloAdaptador();

            DispositivoEstandar d3 = new DispositivoEstandar
            {
                NombreGenerico = "Ultra Led",
                Tipo = "Lampara",
                Consumo = 0.0157,
                UsoMensualMax = 500,
                UsoMensualMin = 30,
                MarcaDispositivo = "BGH",
                ModuloAdaptador = adaptador,
            };

            DispositivoEstandar d4 = new DispositivoEstandar
            {
                NombreGenerico = "Lenovo 2020K",
                Tipo = "Pc",
                Consumo = 0.067,
                UsoMensualMax = 200,
                UsoMensualMin = 30,
                MarcaDispositivo = "Philco"
            };

            dispositivos1.Add(d1);
            dispositivos1.Add(d2);
            dispositivos2.Add(d3);
            dispositivos2.Add(d4);

            dispositivos1.ForEach(d => context.Dispositivos.Add(d));
            dispositivos2.ForEach(d => context.Dispositivos.Add(d));

            // Set Administrador

             Administrador admin1 = new Administrador { IdSistema = "100SSB", Usuario = usuarioAdmin, Nombre = "Jan" , Apellido = "Solo", Domicilio = "Rivadavia 9889", FechaAlta = DateTime.Now };
            context.Administradores.Add(admin1);

            // Set Clientes
            Cliente cliente1 = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Gonzalez",
                TipoDoc = "DNI",
                NroDoc = 10101010,
                Telefono = 12345678,
                Puntos = 11,
                Dispositivos = dispositivos1,
                Transformador = t1,
                Usuario = usuarioCliente1,
                Domicilio = "Rivadavia 2888",
                Latitud = -34.649090,
                Longitud = -58.506350,
                Categoria = categoria1,
                FechaAlta = DateTime.Now
            };

            Cliente cliente2 = new Cliente
            {
                Nombre = "Pedro",
                Apellido = "Soto",
                TipoDoc = "DNI",
                NroDoc = 202020202,
                Telefono = 11768392,
                Puntos = 50,
                Dispositivos = dispositivos2,
                Transformador = t3,
                Usuario = usuarioCliente2,
                Domicilio = "Soler 1010",
                Latitud = -34.665169,
                Longitud = -58.486817,
                Categoria = categoria2,
                FechaAlta = DateTime.Now
            };
            context.Clientes.Add(cliente1);
            context.Clientes.Add(cliente2);

            // Actuador

            Actuador ac1 = new Actuador(new AccionBajarTemperatura()) {AccionSlug = "Bajar temperatura", Dispositivo = d1 };
            Actuador ac2 = new Actuador(new AccionApagar()) { AccionSlug = "Apagar", Dispositivo = d1 };

            context.Actuadores.Add(ac1);
            context.Actuadores.Add(ac2);
        
            // Reglas

            Regla r1 = new Regla() {Tipo = "mayor", Condicion = "Aire Mayor a 24", Valor = 24, Cliente = cliente1};
            Regla r2 = new Regla() {Tipo = "mayor", Condicion = "Tension Alta" , Valor = 80, Cliente = cliente1 };
            Regla r3 = new Regla() {Tipo = "mayor", Condicion = "Movimiento alto", Valor = 5, Cliente = cliente2 };
            Regla r4 = new Regla() {Tipo = "menor", Condicion = "Movimiento bajo", Valor = 30, Cliente = cliente2 };

            context.Reglas.Add(r1);
            context.Reglas.Add(r2);
            context.Reglas.Add(r3);
            context.Reglas.Add(r4);

            List<Regla> listReglas1 = new List<Regla>();
            listReglas1.Add(r1);
            listReglas1.Add(r2);

            List<Regla> listReglas2 = new List<Regla>();
            listReglas2.Add(r3);

            List<Regla> listReglas3 = new List<Regla>();
            listReglas3.Add(r4);

            ac1.ReglasRequeridas = listReglas1;
            ac2.ReglasRequeridas = listReglas2;

            // Sensor

            Sensor s1 = new Sensor() { Magnitud = "°C ", Reglas = listReglas1, Descripcion = "Sensor de temperatura" };
            Sensor s2 = new Sensor() { Magnitud = "kWh", Reglas = listReglas2, Descripcion = "Sensor de tension" };
            Sensor s3 = new Sensor() { Magnitud = "K/h", Reglas = listReglas3, Descripcion = "Sensor de velocidad" };

            context.Sensores.Add(s1);
            context.Sensores.Add(s2);
            context.Sensores.Add(s3);

            // Template Dispositivo

            TemplateDispositivo td1 = new TemplateDispositivo { Tipo = "Aire Acondicionado", EquipoConcreto = "De 3500 frigorías", Inteligente = true, BajoConsumo = false, Consumo = 1.613 };
            TemplateDispositivo td2 = new TemplateDispositivo { Tipo = "Aire Acondicionado", EquipoConcreto = "De 2200 frigorías", Inteligente = true, BajoConsumo = true, Consumo = 1.013 };
            TemplateDispositivo td3 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "Color de tubo fluorocente de 21'", Inteligente = false, BajoConsumo = false, Consumo = 0.075 };
            TemplateDispositivo td4 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "Color de tubo fluorocente de 29' a 34'", Inteligente = false, BajoConsumo = false, Consumo = 0.175 };
            TemplateDispositivo td5 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "LCD de 40'", Inteligente = false, BajoConsumo = false, Consumo = 0.18 };
            TemplateDispositivo td6 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "LED 24'", Inteligente = true, BajoConsumo = true, Consumo = 0.04 };
            TemplateDispositivo td7 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "LED 32'", Inteligente = true, BajoConsumo = true, Consumo = 0.055 };
            TemplateDispositivo td8 = new TemplateDispositivo { Tipo = "Televisor", EquipoConcreto = "LED 40'", Inteligente = true, BajoConsumo = true, Consumo = 0.8 };
            TemplateDispositivo td9 = new TemplateDispositivo { Tipo = "Heladera", EquipoConcreto = "Con freezer", Inteligente = true, BajoConsumo = true, Consumo = 0.09 };
            TemplateDispositivo td10 = new TemplateDispositivo { Tipo = "Heladera", EquipoConcreto = "Sin freezer", Inteligente = true, BajoConsumo = true, Consumo = 0.075 };
            TemplateDispositivo td11 = new TemplateDispositivo { Tipo = "Lavarropas", EquipoConcreto = "Automatico de 5kg con calentamiento de agua", Inteligente = false, BajoConsumo = false, Consumo = 0.875 };
            TemplateDispositivo td12 = new TemplateDispositivo { Tipo = "Lavarropas", EquipoConcreto = "Automatico de 5kg", Inteligente = true, BajoConsumo = true, Consumo = 0.175 };
            TemplateDispositivo td13 = new TemplateDispositivo { Tipo = "Lavarropas", EquipoConcreto = "Semi-automatico de 5kg ", Inteligente = false, BajoConsumo = true, Consumo = 0.1275 };
            TemplateDispositivo td14 = new TemplateDispositivo { Tipo = "Ventilador", EquipoConcreto = "De pie", Inteligente = false, BajoConsumo = true, Consumo = 0.09 };
            TemplateDispositivo td15 = new TemplateDispositivo { Tipo = "Ventilador", EquipoConcreto = "Semi de techo", Inteligente = true, BajoConsumo = true, Consumo = 0.06 };
            TemplateDispositivo td16 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "Halógenas de 40w", Inteligente = true, BajoConsumo = false, Consumo = 0.04 };
            TemplateDispositivo td17 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "Halógenas de 60w", Inteligente = true, BajoConsumo = false, Consumo = 0.06 };
            TemplateDispositivo td18 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "Halógenas de 100w", Inteligente = true, BajoConsumo = false, Consumo = 0.015 };
            TemplateDispositivo td19 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "de 11w", Inteligente = true, BajoConsumo = true, Consumo = 0.011 };
            TemplateDispositivo td20 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "de 15w", Inteligente = true, BajoConsumo = true, Consumo = 0.015 };
            TemplateDispositivo td21 = new TemplateDispositivo { Tipo = "Lámpara", EquipoConcreto = "de 20w", Inteligente = true, BajoConsumo = true, Consumo = 0.02 };
            TemplateDispositivo td22 = new TemplateDispositivo { Tipo = "PC", EquipoConcreto = "De escritorio", Inteligente = true, BajoConsumo = true, Consumo = 0.4 };
            TemplateDispositivo td23 = new TemplateDispositivo { Tipo = "Microondas", EquipoConcreto = "Convencional", Inteligente = false, BajoConsumo = true, Consumo = 0.64 };
            TemplateDispositivo td24 = new TemplateDispositivo { Tipo = "Plancha", EquipoConcreto = "A vapor", Inteligente = false, BajoConsumo = true, Consumo = 0.75 };

            context.TemplateDispositivos.Add(td1);
            context.TemplateDispositivos.Add(td2);
            context.TemplateDispositivos.Add(td3);
            context.TemplateDispositivos.Add(td4);
            context.TemplateDispositivos.Add(td5);
            context.TemplateDispositivos.Add(td6);
            context.TemplateDispositivos.Add(td7);
            context.TemplateDispositivos.Add(td8);
            context.TemplateDispositivos.Add(td9);
            context.TemplateDispositivos.Add(td10);
            context.TemplateDispositivos.Add(td11);
            context.TemplateDispositivos.Add(td12);
            context.TemplateDispositivos.Add(td13);
            context.TemplateDispositivos.Add(td14);
            context.TemplateDispositivos.Add(td15);
            context.TemplateDispositivos.Add(td16);
            context.TemplateDispositivos.Add(td17);
            context.TemplateDispositivos.Add(td18);
            context.TemplateDispositivos.Add(td19);
            context.TemplateDispositivos.Add(td20);
            context.TemplateDispositivos.Add(td21);
            context.TemplateDispositivos.Add(td22);
            context.TemplateDispositivos.Add(td23);
            context.TemplateDispositivos.Add(td24);

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
                admin = new Usuario { Username = "admin1", Password = "admin1", Email = "admin@admin.com"};
                context.Usuarios.Add(admin);
            }

            var cliente1 = context.Usuarios
                .Where(u => u.Username == "cliente1")
                .FirstOrDefault();

            if (cliente1 == null)
            {
                cliente1 = new Usuario { Username = "cliente1", Password = "cliente1", Email = "cliente1@cliente.com"};
                context.Usuarios.Add(cliente1);
            }

            var cliente2 = context.Usuarios
                .Where(u => u.Username == "cliente1")
                .FirstOrDefault();

            if (cliente2 == null)
            {
                cliente2 = new Usuario { Username = "cliente2", Password = "cliente2", Email = "cliente2@cliente.com"};
                context.Usuarios.Add(cliente2);
            }

            usuarios.Add(admin);
            usuarios.Add(cliente1);
            usuarios.Add(cliente2);


            return usuarios;
        }
    }
}
