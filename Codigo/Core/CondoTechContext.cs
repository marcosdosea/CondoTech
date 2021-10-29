using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class CondoTechContext : DbContext
    {
        public CondoTechContext()
        {
        }

        public CondoTechContext(DbContextOptions<CondoTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areacomum> Areacomum { get; set; }
        public virtual DbSet<Avisos> Avisos { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<CondominioHasTarefarecorrente> CondominioHasTarefarecorrente { get; set; }
        public virtual DbSet<Ocorrencias> Ocorrencias { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaHasAreacomum> PessoaHasAreacomum { get; set; }
        public virtual DbSet<PessoaHasCondominio> PessoaHasCondominio { get; set; }
        public virtual DbSet<Tarefarecorrente> Tarefarecorrente { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=y24pqka4e1000;database=CondoTech");
         //   }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areacomum>(entity =>
            {
                entity.HasKey(e => new { e.IdAreaComum, e.CondominioIdCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("areacomum");

                entity.HasIndex(e => e.CondominioIdCondominio)
                    .HasName("fk_areaComum_condominio1_idx");

                entity.Property(e => e.IdAreaComum).HasColumnName("id_areaComum");

                entity.Property(e => e.CondominioIdCondominio).HasColumnName("condominio_id_condominio");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Dias)
                    .HasColumnName("dias")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.HasOne(d => d.CondominioIdCondominioNavigation)
                    .WithMany(p => p.Areacomum)
                    .HasForeignKey(d => d.CondominioIdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_areaComum_condominio1");
            });

            modelBuilder.Entity<Avisos>(entity =>
            {
                entity.HasKey(e => new { e.IdAvisos, e.PessoaIdPessoa, e.CondominioIdCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("avisos");

                entity.HasIndex(e => e.CondominioIdCondominio)
                    .HasName("fk_avisos_condominio1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_avisos_pessoa1_idx");

                entity.Property(e => e.IdAvisos).HasColumnName("id_avisos");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("pessoa_id_pessoa");

                entity.Property(e => e.CondominioIdCondominio).HasColumnName("condominio_id_condominio");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CondominioIdCondominioNavigation)
                    .WithMany(p => p.Avisos)
                    .HasForeignKey(d => d.CondominioIdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avisos_condominio1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Avisos)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avisos_pessoa1");
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.HasKey(e => e.IdCondominio)
                    .HasName("PRIMARY");

                entity.ToTable("condominio");

                entity.Property(e => e.IdCondominio).HasColumnName("id_condominio");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .HasColumnName("rua")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CondominioHasTarefarecorrente>(entity =>
            {
                entity.HasKey(e => new { e.CondominioIdCondominio, e.TarefaRecorrenteIdTarefaRecorrente })
                    .HasName("PRIMARY");

                entity.ToTable("condominio_has_tarefarecorrente");

                entity.HasIndex(e => e.CondominioIdCondominio)
                    .HasName("fk_condominio_has_tarefaRecorrente_condominio1_idx");

                entity.HasIndex(e => e.TarefaRecorrenteIdTarefaRecorrente)
                    .HasName("fk_condominio_has_tarefaRecorrente_tarefaRecorrente1_idx");

                entity.Property(e => e.CondominioIdCondominio).HasColumnName("condominio_id_condominio");

                entity.Property(e => e.TarefaRecorrenteIdTarefaRecorrente).HasColumnName("tarefaRecorrente_id_tarefaRecorrente");

                entity.HasOne(d => d.CondominioIdCondominioNavigation)
                    .WithMany(p => p.CondominioHasTarefarecorrente)
                    .HasForeignKey(d => d.CondominioIdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condominio_has_tarefaRecorrente_condominio1");

                entity.HasOne(d => d.TarefaRecorrenteIdTarefaRecorrenteNavigation)
                    .WithMany(p => p.CondominioHasTarefarecorrente)
                    .HasForeignKey(d => d.TarefaRecorrenteIdTarefaRecorrente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condominio_has_tarefaRecorrente_tarefaRecorrente1");
            });

            modelBuilder.Entity<Ocorrencias>(entity =>
            {
                entity.HasKey(e => e.IdOcorrencias)
                    .HasName("PRIMARY");

                entity.ToTable("ocorrencias");

                entity.HasIndex(e => e.CondominioIdCondominio)
                    .HasName("fk_ocorrencias_condominio1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_ocorrencias_pessoa_idx");

                entity.Property(e => e.IdOcorrencias).HasColumnName("id_ocorrencias");

                entity.Property(e => e.CondominioIdCondominio).HasColumnName("condominio_id_condominio");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("pessoa_id_pessoa");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CondominioIdCondominioNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.CondominioIdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocorrencias_condominio1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocorrencias_pessoa");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaHasAreacomum>(entity =>
            {
                entity.HasKey(e => new { e.PessoaIdPessoa, e.AreaComumIdAreaComum })
                    .HasName("PRIMARY");

                entity.ToTable("pessoa_has_areacomum");

                entity.HasIndex(e => e.AreaComumIdAreaComum)
                    .HasName("fk_pessoa_has_areaComum_areaComum1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_pessoa_has_areaComum_pessoa1_idx");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("pessoa_id_pessoa");

                entity.Property(e => e.AreaComumIdAreaComum).HasColumnName("areaComum_id_areaComum");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.PessoaHasAreacomum)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_areaComum_pessoa1");
            });

            modelBuilder.Entity<PessoaHasCondominio>(entity =>
            {
                entity.HasKey(e => new { e.PessoaIdPessoa, e.CondominioIdCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("pessoa_has_condominio");

                entity.HasIndex(e => e.CondominioIdCondominio)
                    .HasName("fk_pessoa_has_condominio_condominio1_idx");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_pessoa_has_condominio_pessoa1_idx");

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("pessoa_id_pessoa");

                entity.Property(e => e.CondominioIdCondominio).HasColumnName("condominio_id_condominio");

                entity.HasOne(d => d.CondominioIdCondominioNavigation)
                    .WithMany(p => p.PessoaHasCondominio)
                    .HasForeignKey(d => d.CondominioIdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_condominio1");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.PessoaHasCondominio)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_pessoa1");
            });

            modelBuilder.Entity<Tarefarecorrente>(entity =>
            {
                entity.HasKey(e => e.IdTarefaRecorrente)
                    .HasName("PRIMARY");

                entity.ToTable("tarefarecorrente");

                entity.HasIndex(e => e.PessoaIdPessoa)
                    .HasName("fk_tarefaRecorrente_pessoa1_idx");

                entity.Property(e => e.IdTarefaRecorrente).HasColumnName("id_tarefaRecorrente");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Frequencia).HasColumnName("frequencia");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaIdPessoa).HasColumnName("pessoa_id_pessoa");

                entity.HasOne(d => d.PessoaIdPessoaNavigation)
                    .WithMany(p => p.Tarefarecorrente)
                    .HasForeignKey(d => d.PessoaIdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tarefaRecorrente_pessoa1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
