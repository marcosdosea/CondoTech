using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Disponibilidadearea
    {
        public Disponibilidadearea()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdDisponibilidadeArea { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int Vagas { get; set; }
        public int IdAreaComum { get; set; }

        public virtual Areacomum IdAreaComumNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
