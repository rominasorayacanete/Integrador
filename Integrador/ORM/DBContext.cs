namespace Integrador.ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Actuador> Actuador { get; set; }
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<Regla> Regla { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<Template_Dispositivo> Template_Dispositivo { get; set; }
        public virtual DbSet<Transformador> Transformador { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Zona_Geografica> Zona_Geografica { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actuador>()
                .Property(e => e.actu_accion)
                .IsUnicode(false);

            modelBuilder.Entity<Actuador>()
                .HasMany(e => e.Regla)
                .WithMany(e => e.Actuador)
                .Map(m => m.ToTable("Actuador_X_Regla").MapLeftKey("actuador").MapRightKey("regla"));

            modelBuilder.Entity<Administrador>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.cate_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Cliente)
                .WithOptional(e => e.Categoria)
                .HasForeignKey(e => e.clie_categoria)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Dispositivo)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.disp_cliente)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Dispositivo>()
                .Property(e => e.disp_nombre_generico)
                .IsUnicode(false);

            modelBuilder.Entity<Dispositivo>()
                .Property(e => e.disp_tipo_dispositivo)
                .IsUnicode(false);

            modelBuilder.Entity<Dispositivo>()
                .HasMany(e => e.Actuador)
                .WithOptional(e => e.Dispositivo)
                .HasForeignKey(e => e.actu_dispositivo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Dispositivo>()
                .HasMany(e => e.Operacion)
                .WithOptional(e => e.Dispositivo)
                .HasForeignKey(e => e.oper_dispositivo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Regla>()
                .Property(e => e.regl_condicion)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.sens_magnitud)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.Regla)
                .WithOptional(e => e.Sensor)
                .HasForeignKey(e => e.regl_sensor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Template_Dispositivo>()
                .Property(e => e.temp_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.tran_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.tipo_documento)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Administrador)
                .WithOptional(e => e.Usuario)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cliente)
                .WithOptional(e => e.Usuario)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Zona_Geografica>()
                .Property(e => e.zona_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Zona_Geografica>()
                .HasMany(e => e.Cliente)
                .WithOptional(e => e.Zona_Geografica)
                .HasForeignKey(e => e.clie_zona)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Zona_Geografica>()
                .HasMany(e => e.Transformador)
                .WithOptional(e => e.Zona_Geografica)
                .HasForeignKey(e => e.tran_zona)
                .WillCascadeOnDelete();
        }
    }
}
