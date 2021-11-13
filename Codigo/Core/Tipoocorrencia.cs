using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipoocorrencia
    {
        public Tipoocorrencia()
        {
            Ocorrencias = new HashSet<Ocorrencias>();
        }

        public int IdTipoOcorrencia { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
    }
}
