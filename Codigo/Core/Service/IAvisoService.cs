using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvisoService
    {
        int Insert(Avisos avisos);
        Avisos Get(int idAviso);
        IEnumerable<Avisos> obterTodosAvisos();
        void Delete(int idAviso);
        void Update(Avisos avisos);
    }
}
