using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Areacomum
    {
        public int IdAreaComum { get; set; }
        public string Descricao { get; set; }
        public TimeSpan? Hora { get; set; }
        public string Dias { get; set; }
        public int CondominioIdCondominio { get; set; }

        public virtual Condominio CondominioIdCondominioNavigation { get; set; }
    }
}
