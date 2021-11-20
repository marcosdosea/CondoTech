using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
	[TestClass()]
	public class PessoaServiceTests
	{
		private CondoTechContext _context;
		private IPessoaService _pessoaService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<CondoTechContext>();
			builder.UseInMemoryDatabase("CondoTech");
			var options = builder.Options;

			_context = new CondoTechContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var autores = new List<Pessoa>
				{
					new Pessoa { IdPessoa = 1, Nome = "Guilherme", Cpf = "12345678909"},
					new Pessoa { IdPessoa = 2, Nome = "Raul", Cpf = "12312312334"},
					new Pessoa { IdPessoa = 3, Nome = "Rafael", Cpf = "12121212121"},
				};

			_context.AddRange(autores);
			_context.SaveChanges();

			_pessoaService = new PessoaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_pessoaService.Insert(new Pessoa() { IdPessoa = 4, Nome = "Rafael", Cpf = "12312343212" });
			// Assert
			Assert.AreEqual(4, _pessoaService.GetAll().Count());
			var pessoa = _pessoaService.Get(4);
			Assert.AreEqual("Rafael", pessoa.Nome);
			Assert.AreEqual("12312343212", pessoa.Cpf);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var pessoa = _pessoaService.Get(3);
			pessoa.Nome = "Paulo";
			pessoa.Cpf = "98798798767";
			_pessoaService.Update(pessoa);
			pessoa = _pessoaService.Get(3);
			Assert.AreEqual("Paulo", pessoa.Nome);
			Assert.AreEqual("98798798767", pessoa.Cpf);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_pessoaService.Delete(2);
			// Assert
			Assert.AreEqual(2, _pessoaService.GetAll().Count());
			var pessoa = _pessoaService.Get(2);
			Assert.AreEqual(null, pessoa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaAutor = _pessoaService.GetAll();
			// Assert
			Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaAutor);
			Assert.AreEqual(3, listaAutor.Count());
			Assert.AreEqual(1, listaAutor.First().IdPessoa);
			Assert.AreEqual("Guilherme", listaAutor.First().Nome);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var pessoa = _pessoaService.Get(1);
			Assert.IsNotNull(pessoa);
			Assert.AreEqual("Guilherme", pessoa.Nome);
		}

	}
}