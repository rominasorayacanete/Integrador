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
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<DispositivoInteligente> DispositivoInteligente { get; set; }
        public virtual DbSet<Regla> Regla { get; set; }
        public virtual DbSet<TipoDispositivo> TipoDispositivo { get; set; }
        public virtual DbSet<Transformador> Transformador { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actuador>()
                .HasMany(e => e.Regla)
                .WithMany(e => e.Actuador)
                .Map(m => m.ToTable("Regla_X_Actuador").MapLeftKey("actuador").MapRightKey("regla"));

            modelBuilder.Entity<Dispositivo>()
                .Property(e => e.NombreGenerico)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDispositivo>()
                .Property(e => e.EquipoConcreto)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDispositivo>()
                .HasMany(e => e.Actuador)
                .WithOptional(e => e.TipoDispositivo)
                .HasForeignKey(e => e.dispositivo);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.ZonaGeografica)
                .IsUnicode(false);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.Longitud)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.Latitud)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.EnergiaSuministrada)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Tipo_Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasenia)
                .IsUnicode(false);
        }
    }
}
