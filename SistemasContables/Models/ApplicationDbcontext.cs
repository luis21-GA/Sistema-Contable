namespace SistemasContables.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext()
            : base("name=ApplicationDbcontext")
        {
        }

        public virtual DbSet<AsientoDiario> AsientoDiario { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsientoDiario>()
                .Property(e => e.DEscripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Cuentas)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cuentas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cuentas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Cuentas>()
                .HasMany(e => e.AsientoDiario)
                .WithRequired(e => e.Cuentas)
                .HasForeignKey(e => e.CodigoCuenta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cuentas>()
                .HasMany(e => e.AsientoDiario1)
                .WithRequired(e => e.Cuentas1)
                .HasForeignKey(e => e.CodigoCuenta1)
                .WillCascadeOnDelete(false);
        }
    }
}
