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

        IEnumerable<Areacomum> GetByName(string nome);
        IEnumerable<Areacomum> GetAll();
        IQueryable<Areacomum> GetQuery();
    }
}
