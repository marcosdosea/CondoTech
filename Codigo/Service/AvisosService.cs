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
        public void Update(Avisos avisos)
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

        public Avisos Get(int idAviso)
        {
            IEnumerable<Avisos> avisos = GetQuery().Where(avisosModel => avisosModel.IdAviso.Equals(idAviso));
            return avisos.ElementAtOrDefault(0);
        }

        public int Insert(Avisos avisos)
        {
            _context.Add(avisos);
            _context.SaveChanges();
            return avisos.IdAviso;
        }

        public IEnumerable<Avisos> obterTodosAvisos()
        {
            return GetQuery();
        }

        public void Delete(int idAviso)
        {
            var _aviso = _context.Avisos.Find(idAviso);
            _context.Avisos.Remove(_aviso);
            _context.SaveChanges();
        }
    }
}
