using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Avisos
    {
        public int IdAviso { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdPessoa { get; set; }
        public int IdCondominio { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
