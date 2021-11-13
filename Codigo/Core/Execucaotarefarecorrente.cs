using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Execucaotarefarecorrente
    {
        public int IdCondominio { get; set; }
        public int IdTarefaRecorrente { get; set; }
        public DateTime DataExecucao { get; set; }
        public int IdPessoa { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Tarefarecorrente IdTarefaRecorrenteNavigation { get; set; }
    }
}
