using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICondominioService
    {
        int InserirCondominio(Condominio cond);
        void ValidarCondominio(Condominio cond);
        Condominio BuscarCondominio(Condominio cond);
        void RemoverCondominio(Condominio cond);
        void AlterarCondominio(Condominio cond);
        Condominio AlterarCondominio(int id);
    }
}
