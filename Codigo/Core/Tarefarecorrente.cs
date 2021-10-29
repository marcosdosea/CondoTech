using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tarefarecorrente
    {
        public Tarefarecorrente()
        {
            CondominioHasTarefarecorrente = new HashSet<CondominioHasTarefarecorrente>();
        }

        public int IdTarefaRecorrente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }
        public int? Frequencia { get; set; }
        public int PessoaIdPessoa { get; set; }

        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
        public virtual ICollection<CondominioHasTarefarecorrente> CondominioHasTarefarecorrente { get; set; }
    }
}
