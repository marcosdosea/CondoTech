using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    class CondominioService : ICondominioService
    {
        private readonly CondoTechContext _context;

        public CondominioService(CondoTechContext context)
        {
            _context = context;
        }
        public void AlterarCondominio(Condominio cond)
        {
            _context.Update(cond);
            _context.SaveChanges();
        }

        public Condominio BuscarCondominio(int IdCondominio)
        {
            var _auxiliar = _context.Condominio.Find(IdCondominio);
            return _auxiliar;
        }

        public int InserirCondominio(Condominio cond)
        {
            _context.Add(cond);
            _context.SaveChanges();
            return cond.IdCondominio;
        }

        public void RemoverCondominio(Condominio cond)
        {
            var _auxiliar = _context.Condominio.Find(cond.IdCondominio);
            _context.Condominio.Remove(_auxiliar);
            _context.SaveChanges();
        }

        public void ValidarCondominio(Condominio cond)
        {
            throw new NotImplementedException();
        }
    }
}
