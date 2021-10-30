using System;
using System.Collections.Generic;

namespace Core
{
    public partial class PessoaHasCondominio
    {
        public int PessoaIdPessoa { get; set; }
        public int CondominioIdCondominio { get; set; }

        public virtual Condominio CondominioIdCondominioNavigation { get; set; }
        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
    }
}
