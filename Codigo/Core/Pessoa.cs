using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Avisos = new HashSet<Avisos>();
            Ocorrencias = new HashSet<Ocorrencias>();
            PessoaHasAreacomum = new HashSet<PessoaHasAreacomum>();
            PessoaHasCondominio = new HashSet<PessoaHasCondominio>();
            Tarefarecorrente = new HashSet<Tarefarecorrente>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Avisos> Avisos { get; set; }
        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
        public virtual ICollection<PessoaHasAreacomum> PessoaHasAreacomum { get; set; }
        public virtual ICollection<PessoaHasCondominio> PessoaHasCondominio { get; set; }
        public virtual ICollection<Tarefarecorrente> Tarefarecorrente { get; set; }
    }
}
