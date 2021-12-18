using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvisoService
    {
        int Insert(Aviso aviso);
        Aviso Get(int idAviso);
        IEnumerable<Aviso> obterTodosAvisos();
        void Delete(int idAviso, int idPessoa, int idCondominio);
        void Update(Aviso aviso);
    }
}
