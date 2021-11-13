using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITarefaRecorrenteService
    {
        void Update(Tarefarecorrente tarefa);

        int Insert(Tarefarecorrente tarefa);

        void Delete(int IdTarefaRecorrente);

        Tarefarecorrente Get(int IdTarefaRecorrente);

        bool Validar(Tarefarecorrente tarefa);

        IEnumerable<Tarefarecorrente> GetAll();

        IQueryable<Tarefarecorrente> GetQuery();
    }
}