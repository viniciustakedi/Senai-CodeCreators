using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Real_Vagas_API.Domains
{
    public partial class RealVagasContext : DbContext
    {
        public RealVagasContext()
        {
        }

        public RealVagasContext(DbContextOptions<RealVagasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbDados> DbDados { get; set; }
        public virtual DbSet<DbEmpresas> DbEmpresas { get; set; }
        public virtual DbSet<DbInscricao> DbInscricao { get; set; }
        public virtual DbSet<DbTipoUsuario> DbTipoUsuario { get; set; }
        public virtual DbSet<DbUsuarios> DbUsuarios { get; set; }
        public virtual DbSet<DbVagas> DbVagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Gabriel optionsBuilder.UseSqlServer("Server=LAPTOP-U61L15JH\\SQLEXPRESS2019;Database=RealVagas;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=LAPTOP-QQ7IRANA\\SQLEXPRESS2019;Database=RealVagas;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=LAPTOP-OEOULMOC\\SQLEXPRESS;Database=RealVagas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbDados>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.NumMatricula)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DbEmpresas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeResponsavel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.DbEmpresas)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__DbEmpresa__IdTip__286302EC");
            });

            modelBuilder.Entity<DbInscricao>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DbInscricao)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__DbInscric__IdUsu__32E0915F");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.DbInscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__DbInscric__IdVag__31EC6D26");
            });

            modelBuilder.Entity<DbTipoUsuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DbUsuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Curso)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Escola)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCurso)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Turma)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDadosNavigation)
                    .WithMany(p => p.DbUsuarios)
                    .HasForeignKey(d => d.IdDados)
                    .HasConstraintName("FK__DbUsuario__IdDad__2C3393D0");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.DbUsuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__DbUsuario__IdTip__2B3F6F97");
            });

            modelBuilder.Entity<DbVagas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataPublicacao).HasColumnType("date");

                entity.Property(e => e.Descricao).HasColumnType("text");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.LocalVaga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRecrutador)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoContrato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.DbVagas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__DbVagas__IdEmpre__2F10007B");
            });
        }
    }
}
