using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Reserva
    {
        public int IdPessoa { get; set; }
        public int IdAreaComum { get; set; }
        public int IdDisponibilidadeArea { get; set; }
        public DateTime Data { get; set; }
        public int VagasReservadas { get; set; }

        public virtual Areacomum IdAreaComumNavigation { get; set; }
        public virtual Disponibilidadearea IdDisponibilidadeAreaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
