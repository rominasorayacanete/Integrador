using Integrador.Models;
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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transformador> Transformadores { get; set; }
        public DbSet<ZonaGeografica> ZonaGeograficas { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<TemplateDispositivo> TemplateDispositivos { get; set; }
       
    }
}