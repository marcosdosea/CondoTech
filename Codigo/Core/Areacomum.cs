using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Areacomum
    {
        public Areacomum()
        {
            Disponibilidadearea = new HashSet<Disponibilidadearea>();
            Reserva = new HashSet<Reserva>();
        }

        public int IdAreaComum { get; set; }
        public int IdCondominio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual Condominio IdCondominioNavigation { get; set; }
        public virtual ICollection<Disponibilidadearea> Disponibilidadearea { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
