using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tarefarecorrente
    {
        public Tarefarecorrente()
        {
            Execucaotarefarecorrente = new HashSet<Execucaotarefarecorrente>();
        }

        public int IdTarefaRecorrente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? RepeticaoDias { get; set; }

        public virtual ICollection<Execucaotarefarecorrente> Execucaotarefarecorrente { get; set; }
    }
}
