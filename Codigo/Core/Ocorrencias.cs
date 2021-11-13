using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Ocorrencias
    {
        public int IdOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int IdPessoa { get; set; }
        public int IdCondominio { get; set; }
        public int IdTipoOcorrencia { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Tipoocorrencia IdTipoOcorrenciaNavigation { get; set; }
    }
}
