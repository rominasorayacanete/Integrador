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
        public virtual DbSet<ZonaGeografica> ZonaGeografica { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actuador>()
                .HasMany(e => e.Regla)
                .WithMany(e => e.Actuador)
                .Map(m => m.ToTable("Regla_X_Actuador").MapLeftKey("actuador").MapRightKey("regla"));

            modelBuilder.Entity<Dispositivo>()
                .Property(e => e.nombre_generico)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDispositivo>()
                .Property(e => e.EquipoConcreto)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDispositivo>()
                .HasMany(e => e.Actuador)
                .WithOptional(e => e.TipoDispositivo)
                .HasForeignKey(e => e.dispositivo);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.zona_id);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.longitud);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.latitud);

            modelBuilder.Entity<Transformador>()
                .Property(e => e.energia_suministrada);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
