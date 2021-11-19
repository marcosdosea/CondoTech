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

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Areacomum> Areacomum { get; set; }
        public virtual DbSet<Aviso> Aviso { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Condomino> Condomino { get; set; }
        public virtual DbSet<Disponibilidadearea> Disponibilidadearea { get; set; }
        public virtual DbSet<Execucaotarefarecorrente> Execucaotarefarecorrente { get; set; }
        public virtual DbSet<Ocorrencias> Ocorrencias { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Tarefarecorrente> Tarefarecorrente { get; set; }
        public virtual DbSet<Tipoocorrencia> Tipoocorrencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=MasterOv;database=CondoTech");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("administradores");

                entity.HasIndex(e => e.IdCondominio)
                    .HasName("fk_pessoa_has_condominio_condominio2_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_pessoa_has_condominio_pessoa2_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("enum('SINDICO','VICE')");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_condominio2");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_pessoa2");
            });

            modelBuilder.Entity<Areacomum>(entity =>
            {
                entity.HasKey(e => e.IdAreaComum)
                    .HasName("PRIMARY");

                entity.ToTable("areacomum");

                entity.HasIndex(e => e.IdCondominio)
                    .HasName("fk_areaComum_condominio1_idx");

                entity.Property(e => e.IdAreaComum).HasColumnName("idAreaComum");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Areacomum)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_areaComum_condominio1");
            });

            modelBuilder.Entity<Aviso>(entity =>
            {
                entity.HasKey(e => new { e.idAviso, e.idPessoa, e.idCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("aviso");

                entity.HasIndex(e => e.idCondominio)
                    .HasName("fk_avisos_condominio1_idx");

                entity.HasIndex(e => e.idPessoa)
                    .HasName("fk_avisos_pessoa1_idx");

                entity.Property(e => e.idAviso).HasColumnName("idAviso");

                entity.Property(e => e.idPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.idCondominio).HasColumnName("idCondominio");

                entity.Property(e => e.data).HasColumnName("data");

                entity.Property(e => e.descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Aviso)
                    .HasForeignKey(d => d.idCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avisos_condominio1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Aviso)
                    .HasForeignKey(d => d.idPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avisos_pessoa1");
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.HasKey(e => e.IdCondominio)
                    .HasName("PRIMARY");

                entity.ToTable("condominio");

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

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

            modelBuilder.Entity<Condomino>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdCondominio })
                    .HasName("PRIMARY");

                entity.ToTable("condomino");

                entity.HasIndex(e => e.IdCondominio)
                    .HasName("fk_pessoa_has_condominio_condominio1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_pessoa_has_condominio_pessoa1_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Condomino)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_condominio1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Condomino)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_condominio_pessoa1");
            });

            modelBuilder.Entity<Disponibilidadearea>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidadeArea)
                    .HasName("PRIMARY");

                entity.ToTable("disponibilidadearea");

                entity.HasIndex(e => e.IdAreaComum)
                    .HasName("fk_DisponibilidadeArea_areaComum1_idx");

                entity.Property(e => e.IdDisponibilidadeArea).HasColumnName("idDisponibilidadeArea");

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasColumnName("diaSemana")
                    .HasColumnType("enum('SEGUNDA','TERCA','QUARTA','QUINTA','SEXTA','SABADO','DOMINGO')");

                entity.Property(e => e.HoraFim).HasColumnName("horaFim");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.IdAreaComum).HasColumnName("idAreaComum");

                entity.Property(e => e.Vagas)
                    .HasColumnName("vagas")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdAreaComumNavigation)
                    .WithMany(p => p.Disponibilidadearea)
                    .HasForeignKey(d => d.IdAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DisponibilidadeArea_areaComum1");
            });

            modelBuilder.Entity<Execucaotarefarecorrente>(entity =>
            {
                entity.HasKey(e => new { e.IdCondominio, e.IdTarefaRecorrente })
                    .HasName("PRIMARY");

                entity.ToTable("execucaotarefarecorrente");

                entity.HasIndex(e => e.IdCondominio)
                    .HasName("fk_condominio_has_tarefaRecorrente_condominio1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_ExecucaoTarefaRecorrente_pessoa1_idx");

                entity.HasIndex(e => e.IdTarefaRecorrente)
                    .HasName("fk_condominio_has_tarefaRecorrente_tarefaRecorrente1_idx");

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

                entity.Property(e => e.IdTarefaRecorrente).HasColumnName("idTarefaRecorrente");

                entity.Property(e => e.DataExecucao).HasColumnName("dataExecucao");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Execucaotarefarecorrente)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condominio_has_tarefaRecorrente_condominio1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Execucaotarefarecorrente)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ExecucaoTarefaRecorrente_pessoa1");

                entity.HasOne(d => d.IdTarefaRecorrenteNavigation)
                    .WithMany(p => p.Execucaotarefarecorrente)
                    .HasForeignKey(d => d.IdTarefaRecorrente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condominio_has_tarefaRecorrente_tarefaRecorrente1");
            });

            modelBuilder.Entity<Ocorrencias>(entity =>
            {
                entity.HasKey(e => e.IdOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("ocorrencias");

                entity.HasIndex(e => e.IdCondominio)
                    .HasName("fk_ocorrencias_condominio1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_ocorrencias_pessoa_idx");

                entity.HasIndex(e => e.IdTipoOcorrencia)
                    .HasName("fk_ocorrencias_tipoOcorrencia1_idx");

                entity.Property(e => e.IdOcorrencia).HasColumnName("idOcorrencia");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdCondominio).HasColumnName("idCondominio");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdTipoOcorrencia).HasColumnName("idTipoOcorrencia");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocorrencias_condominio1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocorrencias_pessoa");

                entity.HasOne(d => d.IdTipoOcorrenciaNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.IdTipoOcorrencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ocorrencias_tipoOcorrencia1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('ATIVO','BLOQUEADO','EXCLUIDO')")
                    .HasDefaultValueSql("'BLOQUEADO'");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdAreaComum })
                    .HasName("PRIMARY");

                entity.ToTable("reserva");

                entity.HasIndex(e => e.IdAreaComum)
                    .HasName("fk_pessoa_has_areaComum_areaComum1_idx");

                entity.HasIndex(e => e.IdDisponibilidadeArea)
                    .HasName("fk_Reserva_DisponibilidadeArea1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_pessoa_has_areaComum_pessoa1_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdAreaComum).HasColumnName("idAreaComum");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdDisponibilidadeArea).HasColumnName("idDisponibilidadeArea");

                entity.Property(e => e.VagasReservadas)
                    .HasColumnName("vagasReservadas")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdAreaComumNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_areaComum_areaComum1");

                entity.HasOne(d => d.IdDisponibilidadeAreaNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdDisponibilidadeArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reserva_DisponibilidadeArea1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_has_areaComum_pessoa1");
            });

            modelBuilder.Entity<Tarefarecorrente>(entity =>
            {
                entity.HasKey(e => e.IdTarefaRecorrente)
                    .HasName("PRIMARY");

                entity.ToTable("tarefarecorrente");

                entity.Property(e => e.IdTarefaRecorrente).HasColumnName("idTarefaRecorrente");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RepeticaoDias).HasColumnName("repeticaoDias");
            });

            modelBuilder.Entity<Tipoocorrencia>(entity =>
            {
                entity.HasKey(e => e.IdTipoOcorrencia)
                    .HasName("PRIMARY");

                entity.ToTable("tipoocorrencia");

                entity.Property(e => e.IdTipoOcorrencia).HasColumnName("idTipoOcorrencia");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
