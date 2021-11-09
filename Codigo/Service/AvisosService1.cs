using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    public class AvisosService : IAvisoService
    {
        private readonly CondoTechContext _context;

        public AvisosService(CondoTechContext context) {
            _context = context;
        }
        public void alterar(Avisos avisos)
        {
            _context.Update(avisos);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        private IQueryable<Avisos> GetQuery() {
            IQueryable<Avisos> tb_avisos = _context.Avisos;
            var query = from avisos in tb_avisos select avisos;
            return query;
        }

        public Avisos buscar(int idAviso)
        {
            IEnumerable<Avisos> avisos = GetQuery().Where(avisosModel => avisosModel.IdAvisos.Equals(idAviso));
            return avisos.ElementAtOrDefault(0);
        }

        public int inserir(Avisos avisos)
        {
            _context.Add(avisos);
            _context.SaveChanges();
            return avisos.IdAvisos;
        }

        public IEnumerable<Avisos> obterTodosAvisos()
        {
            return GetQuery();
        }

        public void remover(int idAviso)
        {
            var _aviso = _context.Avisos.Find(idAviso);
            _context.Avisos.Remove(_aviso);
            _context.SaveChanges();
        }
    }
}
