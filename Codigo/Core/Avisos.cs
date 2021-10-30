using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Avisos
    {
        public int IdAvisos { get; set; }
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }
        public int PessoaIdPessoa { get; set; }
        public int CondominioIdCondominio { get; set; }

        public virtual Condominio CondominioIdCondominioNavigation { get; set; }
        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
    }
}
