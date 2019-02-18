using Integrador.Models;
using Integrador.Models.Abstract;
using Integrador.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Integrador.DAL
{
    public class Context : DbContext
    {
        public Context()
    : base("DBContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transformador> Transformadores { get; set; }
        public DbSet<ZonaGeografica> ZonaGeograficas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<DispositivoInteligente> DispositivosInteligentes { get; set; }
        public DbSet<DispositivoEstandar> DispositivoEstandar { get; set; }
        public DbSet<MarcaDispositivo> MarcaDispositivo { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<TemplateDispositivo> TemplateDispositivos { get; set; }
        public DbSet<ModuloAdaptador> ModulosAdaptadores { get; set; }
        public DbSet<Regla> Reglas { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Actuador> Actuadores { get; set; }
    }
}