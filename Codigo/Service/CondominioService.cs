using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Services
{
   public  class CondominioService
    {

		public class CondominioService : ICondominioService
		{
			private readonly CondoTechContext _context;

			public CondominioService(CondoTechContext context)
			{
				_context = context;
			}

			/// <summary>
			/// Insere um novo autor no base de dados
			/// </summary>
			/// <param name="autor">dados do autor</param>
			/// <returns></returns>
			public int Inserir(Condominio condominio)
			{
				_context.Add(condominio);
				_context.SaveChanges();
				return condominio.IdCondominio;
			}

			/// <summary>
			/// Atualiza os dados do autor na base de dados
			/// </summary>
			/// <param name="autor">dados do autor</param>
			public void Editar(Condominio condominio)
			{
				_context.Update(condominio);
				_context.SaveChanges();
			}

	
			public void Remover(int id)
			{
				var _autor = _context.Condominio.Find(id);
				_context.Condominio.Remove(_autor);
				_context.SaveChanges();
			}

			/// <summary>
			/// Consulta genérica aos dados do autor
			/// </summary>
			/// <returns></returns>
			private IQueryable<Condominio> GetQuery()
			{
				//IQueryable<Autor> listaAutor = _context.Autor;
				var query = from autor in _context.Condominio
							select autor;
				return query;
			}

			/// <summary>
			/// Obtém todos os autores
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Condominio> ObterTodos()
			{
				return GetQuery();
			}

			/// <summary>
			/// Obter Todos os autores ordenado por noem
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Condominio> ObterTodosOrdenadoPorNome()
			{
				var query = from autor in _context.Condominio
							orderby autor.Nome
							select autor;
				return query;
			}

			/// <summary>
			/// REtorna o número de autores cadastrados
			/// </summary>
			/// <returns></returns>
			public int GetNumeroAutoresComALetraA()
			{
				//IQueryable<Autor> listaAutor = _context.Autor;
				//var query = from autor in listaAutor
				//			where autor.Nome.StartsWith("A")
				//			select autor;
				//return query.Count();

				return _context.Condominio.
					Where(autor => autor.Nome.StartsWith("A")).
					OrderBy(autor => autor.Nome).
					Count();
			}

			/// <summary>
			/// Obtém os dados do primeiro autor cadastrado na base de dados.
			/// </summary>
			/// <returns></returns>
			public Condominio ObterPrimeiroAutor()
			{
				return _context.Condominio.FirstOrDefault();
			}


			/// <summary>
			/// Obtém pelo identificado do autor
			/// </summary>
			/// <param name="idAutor"></param>
			/// <returns></returns>
			public Condominio Obter(int id)
			{
				IEnumerable<Condominio> autores = GetQuery().Where(condominioModel => condominioModel.IdCondominio.Equals(id));

				return autores.ElementAtOrDefault(0);
			}

			
			public IEnumerable<Condominio> ObterPorNome(string nome)
			{
				IEnumerable<Condominio> condominios = GetQuery()
					.Where(CondominioModel => CondominioModel.Nome.
					StartsWith(nome));
				return condominios;
			}

			public IEnumerable<Condominio> ObterPorNomeContendo(string nome)
			{
				var query = from autor in _context.Condominio
							where autor.Nome.Contains(nome)
							select autor;
				return query;
			}

			/// <summary>
			/// Obtém autores ordenado de forma descendente
			/// </summary>
			/// <param name="nome"></param>
			/// <returns></returns>
			public IEnumerable<CondominioDTO> ObterPorNomeOrdenadoDescending(string nome)
			{
				var query = from autor in _context.Condominio
							where autor.Nome.StartsWith(nome)
							orderby autor.Nome descending
						//	select new AutorDTO
							{

							};
				return query;
			}
		}




	}
}
