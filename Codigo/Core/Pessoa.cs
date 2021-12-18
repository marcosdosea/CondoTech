using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Administradores = new HashSet<Administradores>();
            Aviso = new HashSet<Aviso>();
            Condomino = new HashSet<Condomino>();
            Execucaotarefarecorrente = new HashSet<Execucaotarefarecorrente>();
            Ocorrencias = new HashSet<Ocorrencias>();
            Reserva = new HashSet<Reserva>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Administradores> Administradores { get; set; }
        public virtual ICollection<Aviso> Aviso { get; set; }
        public virtual ICollection<Condomino> Condomino { get; set; }
        public virtual ICollection<Execucaotarefarecorrente> Execucaotarefarecorrente { get; set; }
        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
