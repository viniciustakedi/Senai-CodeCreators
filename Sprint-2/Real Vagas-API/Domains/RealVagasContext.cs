﻿using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OEOULMOC\\SQLEXPRESS;Database=RealVagas;Trusted_Connection=True;");
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
                    .HasConstraintName("FK__DbEmpresa__IdTip__4222D4EF");
            });

            modelBuilder.Entity<DbInscricao>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DbInscricao)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__DbInscric__IdUsu__5441852A");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.DbInscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__DbInscric__IdVag__534D60F1");
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
                    .HasConstraintName("FK__DbUsuario__IdDad__45F365D3");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.DbUsuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__DbUsuario__IdTip__44FF419A");
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

                entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoContrato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.DbVagas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__DbVagas__IdEmpre__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}