namespace DBSystemTP.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using DBSystemTP.Entities.Models;
    



    public partial class DBSystemContext : DbContext
    {
        public DBSystemContext()
            : base("name=DBSystemContext")
        {
        }

        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudade>()
                 .HasRequired<Departamento>(c => c.Departamento)
                 .WithMany(d => d.Ciudades)
                .HasForeignKey<int>(c => c.DepartamentoId);
                //.HasOptional(e => e.Usuario)
                //.WithRequired(e => e.Ciudade);

            modelBuilder.Entity<Departamento>()
                .HasRequired<Pais>(d => d.Pais)
                 .WithMany(p => p.Departamentos)
                .HasForeignKey<int>(d => d.PaisId);
          
            //modelBuilder.Entity<TiposDocumento>()
            //    .HasRequired(e => e.Usuario)
            //    .WithRequiredPrincipal(e => e.TiposDocumento);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NumeroIdentificacion)
                .IsUnicode(false);

            //modelBuilder.Entity<Usuario>()
            //    .HasRequired(u => u.TiposDocumento)
            //    .WithRequiredPrincipal(t => t.Usuario);

        }
    }
}
