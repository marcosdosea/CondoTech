using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TarefaRecorrenteService : ITarefaRecorrenteService
    {
        private readonly CondoTechContext _context;

        public TarefaRecorrenteService(CondoTechContext context)
        {
            _context = context;
        }
        public void Alterar(Tarefarecorrente tarefa)
        {
            _context.Update(tarefa);
            _context.SaveChanges();
        }

        public Tarefarecorrente Buscar(int IdTarefaRecorrente)
        {
            var _tarefa = _context.Tarefarecorrente.Find(IdTarefaRecorrente);
            return _tarefa;
        }

        public int Inserir(Tarefarecorrente tarefa)
        {

            _context.Add(tarefa);
            _context.SaveChanges();
            return tarefa.IdTarefaRecorrente;
        }

        public void Remover(int IdTarefaRecorrente)
        {
            var _tarefa = _context.Tarefarecorrente.Find(IdTarefaRecorrente);
            _context.Tarefarecorrente.Remove(_tarefa);
            _context.SaveChanges();
        }

        public bool Validar(Tarefarecorrente tarefa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefarecorrente> GetAll()
        {
            return GetQuery();
        }

        public IQueryable<Tarefarecorrente>GetQuery()
        {
            var query = from Tarefarecorrente in _context.Tarefarecorrente
                        select Tarefarecorrente;
            return query;
        }
    }
}
