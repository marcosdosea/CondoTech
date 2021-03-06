using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Condomino
    {
        public int IdPessoa { get; set; }
        public int IdCondominio { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
