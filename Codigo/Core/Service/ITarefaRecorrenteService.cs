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
        void Alterar(Tarefarecorrente tarefa);

        int Inserir(Tarefarecorrente tarefa);

        void Remover(int IdTarefaRecorrente);

        Tarefarecorrente Buscar(int IdTarefaRecorrente);

        bool Validar(Tarefarecorrente tarefa);

        IEnumerable<Tarefarecorrente> GetAll();

        IQueryable<Tarefarecorrente> GetQuery();
    }
}