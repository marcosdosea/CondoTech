using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AvisoService : IAvisoService
    {
        private readonly CondoTechContext _context;

        public AvisoService(CondoTechContext context)
        {
            _context = context;
        }
        public void Update(Aviso aviso)
        {
            _context.Update(aviso);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        private IQueryable<Aviso> GetQuery()
        {
            IQueryable<Aviso> tb_avisos = _context.Aviso;
            var query = from avisos in tb_avisos select avisos;
            return query;
        }

        public Aviso Get(int idAviso)
        {
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

        public void Delete(int idAviso, int idPessoa, int idCondominio)
        {
            Console.WriteLine(idPessoa + " / " + idCondominio);
            var _aviso = _context.Aviso.Find(idAviso, idPessoa, idCondominio);
            _context.Remove(_aviso);
            _context.SaveChanges();
        }
    }
}
