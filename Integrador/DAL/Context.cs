namespace Integrador.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Integrador.Models;

    public class Context : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'Context' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Integrador.DAL.Context' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Context'  en el archivo de configuración de la aplicación.
        public Context()
            : base("name=Context")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Administrador> Administradores { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Dispositivo> Dispositivos { get; set; }
        public virtual DbSet<DispositivoEstandar> DispositivosEstandar { get; set; }
        public virtual DbSet<DispositivoInteligente> DispositivosInteligentes { get; set; }
        public virtual DbSet<Adaptador> Adaptadores { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<ZonaGeografica> ZonasGeograficas { get; set; }
        public virtual DbSet<Transformador> Transformadores { get; set; }
        public virtual DbSet<Operacion> Operaciones { get; set; }
        public virtual DbSet<TemplateDispositivo> TemplateDispositivos { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}