using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAreacomumService
    {
        int Insert(Areacomum areacomum);

        void Update(Areacomum areacomum);

        Areacomum Get(int idAreacomum);

        void Delete(int idAreacomum);

        bool Validar(Areacomum areacomum);

        //IEnumerable<Areacomum> ObterPorNome(string nome);
        //IEnumerable<Areacomum> ObterTodos();

        //IEnumerable<Areacomum> ObterPorNomeOrdenadoDescendign(string nome);
    }
}
