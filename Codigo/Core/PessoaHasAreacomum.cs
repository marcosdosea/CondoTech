using System;
using System.Collections.Generic;

namespace Core
{
    public partial class PessoaHasAreacomum
    {
        public int PessoaIdPessoa { get; set; }
        public int AreaComumIdAreaComum { get; set; }

        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
    }
}
