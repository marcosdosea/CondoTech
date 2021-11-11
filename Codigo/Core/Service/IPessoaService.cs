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
        void Alterar(Pessoa pessoa);

        int Inserir(Pessoa pessoa);

        void Remover(int IdPessoa);

        Pessoa Buscar(int IdPessoa);

        bool Validar(Pessoa pessoa);

        IEnumerable<Pessoa> GetAll();

        IQueryable<Pessoa> GetQuery();
    }
}
