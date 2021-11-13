using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPessoaService
    {
        void Update(Pessoa pessoa);

        int Insert(Pessoa pessoa);

        void Delete(int IdPessoa);

        Pessoa Get(int IdPessoa);

        bool Validar(Pessoa pessoa);

        IEnumerable<Pessoa> GetAll();

        IQueryable<Pessoa> GetQuery();
    }
}
