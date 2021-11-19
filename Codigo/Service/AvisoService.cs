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
            IQueryable<Aviso> tb_aviso = _context.Aviso;
            var query = from aviso in tb_aviso select aviso;
            return query;
        }

        public Aviso Get(int idAviso)
        {
            IEnumerable<Aviso> aviso = GetQuery().Where(avisoModel => avisoModel.idAviso.Equals(idAviso));
            return aviso.ElementAtOrDefault(0);
        }

        public int Insert(Aviso avisos)
        {
            _context.Add(avisos);
            _context.SaveChanges();
            return avisos.idAviso;
        }

        public IEnumerable<Aviso> GetAll()
        {
            return GetQuery();
        }

        public void Delete(int idAviso)
        {
            var _aviso = _context.Aviso.Find(idAviso);
            _context.Aviso.Remove(_aviso);
            _context.SaveChanges();
        }
    }
}
