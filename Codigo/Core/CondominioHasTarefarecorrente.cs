using System;
using System.Collections.Generic;

namespace Core
{
    public partial class CondominioHasTarefarecorrente
    {
        public int CondominioIdCondominio { get; set; }
        public int TarefaRecorrenteIdTarefaRecorrente { get; set; }

        public virtual Condominio CondominioIdCondominioNavigation { get; set; }
        public virtual Tarefarecorrente TarefaRecorrenteIdTarefaRecorrenteNavigation { get; set; }
    }
}
