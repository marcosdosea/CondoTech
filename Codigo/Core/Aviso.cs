using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Aviso
    {
        public int idAviso { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public int idPessoa { get; set; }
        public int idCondominio { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
