using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvisoService
    {
        int inserir(Avisos avisos);
        Avisos buscar(int idAviso);
        IEnumerable<Avisos> obterTodosAvisos();
        void remover(int idAviso);
        void alterar(Avisos avisos);
    }
}
