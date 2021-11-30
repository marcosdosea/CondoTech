using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Administradores
    {
        public int IdPessoa { get; set; }
        public int IdCondominio { get; set; }
        public string Tipo { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
