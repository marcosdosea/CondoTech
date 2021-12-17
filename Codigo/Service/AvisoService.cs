using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    public class AvisoService : IAvisoService
    {
        private readonly CondoTechContext _context;

        public AvisoService(CondoTechContext context) {
            _context = context;
        }
        public void Update(Aviso aviso)
        {
            _context.Update(aviso);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        private IQueryable<Aviso> GetQuery() {
            IQueryable<Aviso> tb_avisos = _context.Aviso;
            var query = from avisos in tb_avisos select avisos;
            return query;
        }

        public Aviso Get(int idAviso) {
            IEnumerable<Aviso> avisos = GetQuery().Where(avisosModel => avisosModel.idAviso.Equals(idAviso));
            return avisos.ElementAtOrDefault(0);
        }

        public int Insert(Aviso aviso)
        {
            _context.Add(aviso);
            _context.SaveChanges();
            return aviso.idAviso;
        }

        public IEnumerable<Aviso> obterTodosAvisos()
        {
            return GetQuery();
        }

        public void Delete(int idAviso)
        {
            var _aviso = _context.Aviso.Find(idAviso);
            _context.Remove(_aviso);
            _context.SaveChanges();
        }
    }
}
