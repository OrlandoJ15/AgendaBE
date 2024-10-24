using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Entidades.Models
{
    public partial class AgendaContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AgendaContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Canton> Cantons { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<Provincia> Provincia { get; set; } = null!;
        public virtual DbSet<Subcategoria> Subcategoria { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
                var connectionString = _configuration.GetConnectionString("AgendaBD");
                optionsBuilder.UseSqlServer(connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canton>(entity =>
            {
                entity.ToTable("Canton");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Canton1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("canton");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.CodigoProvincia).HasColumnName("codigoProvincia");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.AzureURL)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("azureURL");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.EstadoAzure).HasColumnName("estadoAzure");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("facebook");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Instagram)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("instagram");

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("linkedIn");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Strikes).HasColumnName("strikes");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Telefono2).HasColumnName("telefono2");

                entity.Property(e => e.Tiktok)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tiktok");

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("website");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Categoria");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Provincia");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.ToTable("Parametro");

                entity.Property(e => e.IdParametro).ValueGeneratedNever();

                entity.Property(e => e.Urlfacebook)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URLFacebook");

                entity.Property(e => e.Urlinstagram)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URLInstagram");

                entity.Property(e => e.Urlpagina)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URLPagina");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__provinci__3213E83FC2C441CB");

                entity.Property(e => e.IdProvincia)
                    .ValueGeneratedNever()
                    .HasColumnName("idProvincia");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.provincia)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
            });

            modelBuilder.Entity<Subcategoria>(entity =>
            {
                entity.HasKey(e => e.IdSubCategoria);

                entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Subcategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Subcategoria_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
