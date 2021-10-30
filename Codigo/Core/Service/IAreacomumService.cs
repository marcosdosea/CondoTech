using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAreacomumService
    {
        int Inserir(Areacomum areacomum);

        void Alterar(Areacomum areacomum);

        Areacomum Buscar(int idAreacomum);

        void Remover(int idAreacomum);

        bool Validar(Areacomum areacomum);

        //IEnumerable<Areacomum> ObterPorNome(string nome);
        //IEnumerable<Areacomum> ObterTodos();

        //IEnumerable<Areacomum> ObterPorNomeOrdenadoDescendign(string nome);
    }
}
