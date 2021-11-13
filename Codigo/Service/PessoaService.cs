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
    public class PessoaService : IPessoaService
    {
        private readonly CondoTechContext _context;

        public PessoaService(CondoTechContext context)
        {
            _context = context;
        }
        public void Update(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public Pessoa Get(int IdPessoa)
        {
            var _pessoa = _context.Pessoa.Find(IdPessoa);
            return _pessoa;
        }

        public int Insert(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
        }

        public void Delete(int IdPessoa)
        {
            var _pessoa = _context.Pessoa.Find(IdPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
        }

        public bool Validar(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return GetQuery();
        }

        public IQueryable<Pessoa> GetQuery()
        {
            var query = from Pessoa in _context.Pessoa
                        select Pessoa;
            return query;
        }

    }
}
