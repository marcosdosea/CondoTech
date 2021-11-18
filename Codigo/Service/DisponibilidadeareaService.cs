using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DisponibilidadeareaService : IDisponibilidadeareaService
    {
        private readonly CondoTechContext _context;


        public DisponibilidadeareaService(CondoTechContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Editar a disponibilidade da area na base de dados
        /// </summary>
        /// <param name="disponibilidadearea">dados da disponibilidadearea</param>
        public void Update(Disponibilidadearea disponibilidadearea)
        {
            _context.Update(disponibilidadearea);
            _context.SaveChanges();
        }

        /// <summary>
        /// busca pela disponibilidade da area na base de dados
        /// </summary>
        /// <param name="idAreacomum">dados da disponibilidadearea</param>
        /// <returns>retorna a disponibilidade ou nulo quando não for encontrado</returns>
        public Disponibilidadearea Get(int IdDisponibilidadearea)
        {
            var _disponibilidadearea = _context.Disponibilidadearea.Find(IdDisponibilidadearea);
            return _disponibilidadearea;
        }

        /// <summary>
        /// Insert disponibilidadearea na base de dados
        /// </summary>
        /// <param name="disponibilidadearea">dados da area comum</param>
        /// <returns>retorna o IdDisponibilidadeArea gerado</returns>
        public int Insert(Disponibilidadearea disponibilidadearea)
        {
            _context.Add(disponibilidadearea);
            _context.SaveChanges();
            return disponibilidadearea.IdDisponibilidadeArea;
        }


        /// <summary>
        /// Remove uma disponibilidade de area da base de dados
        /// </summary>
        /// <param name="IdDisponibiladeArea">a ser removido</param>
        public void Delete(int IdDisponibiladeArea)
        {
            var _disponibilidadearea = _context.Disponibilidadearea.Find(IdDisponibiladeArea);
            _context.Remove(_disponibilidadearea);
            _context.SaveChanges();
        }

        /// <summary>
        /// Busca todas as disponibilidades de areas cadastradas
        /// </summary>
        /// <returns>irá retornar outro metodo, que será uma pesquisa generalista</returns>
        public IEnumerable<Disponibilidadearea> GetAll()
        {
            return GetQuery();
        }

        /// <summary>
        /// apenas faz uma busca generica
        /// </summary>
        /// <returns>irá retornar o resultado da busca</returns>
        public IQueryable<Disponibilidadearea> GetQuery()
        {
            var query = from Disponibilidadearea in _context.Disponibilidadearea
                        select Disponibilidadearea;
            return query;
        }
        /// <summary>
        /// Procura por todas as disponibilidades de areas de acordo com o dia da semana informado
        /// </summary>
        /// <param name="DiaSemana">a ser procurado</param>
        /// <returns>retorna a disponibilidade de areas que contém o parametro DiaSemana</returns>
        public IEnumerable<Disponibilidadearea> GetByDiaSemana(string DiaSemana)
        {
            var query = from Disponibilidadearea in _context.Disponibilidadearea
                        where Disponibilidadearea.DiaSemana.Contains(DiaSemana)
                        select Disponibilidadearea;
            return query;
        }

        /// <summary>
        /// Valida uma disponibilidade de area na base de dados
        /// </summary>
        /// <param name="disponibilidadearea">a ser validado</param>
        /// <returns>retorna true caso seja validado ou false caso nao seja</returns>
        //apenas para ter algo implementado
        public bool Validar(Disponibilidadearea disponibilidadearea)
        {
            throw new NotImplementedException();
        }
    }
}
