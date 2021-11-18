using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICondominioService
    {
        int Insert(Condominio cond);
        void ValidarCondominio(Condominio cond);
        Condominio Get(int IdCondominio);
        void Delete(int IdCondominio);
        void Update(Condominio cond);
        public IEnumerable<Condominio> GetByName(string nome);
        public IEnumerable<Condominio> GetAll();

        public IQueryable<Condominio> GetQuery();
    }
}
