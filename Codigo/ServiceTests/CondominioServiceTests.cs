using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
	[TestClass()]
	public class CondominioServiceTests
	{
		private CondoTechContext _context;
		private ICondominioService _condominioService;

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
			var condominios = new List<Condominio>
				{
					new Condominio { IdCondominio = 1, Nome = "Machado de Assis", Cnpj = "1917-12-31"},
					new Condominio { IdCondominio = 2, Nome = "Ian S. Sommervile", Cnpj = "1935-12-31"},
					new Condominio { IdCondominio = 3, Nome = "Gleford Myers", Cnpj = "1900-11-20"},
				};

			_context.AddRange(condominios);
			_context.SaveChanges();

			_condominioService = new CondominioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_condominioService.Insert(new Condominio() { IdCondominio = 4, Nome = "Graciliano Ramos", Cnpj = "1900-12-25" });
			// Assert
			Assert.AreEqual(4, _condominioService.GetAll().Count());
			var condominio = _condominioService.Get(4);
			Assert.AreEqual("Graciliano Ramos", condominio.Nome);
			Assert.AreEqual("1900-12-25", condominio.Cnpj);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var condominio = _condominioService.Get(3);
			condominio.Nome = "Paulo Coelho";
			condominio.Cnpj = "1950-11-21";
			_condominioService.Update(condominio);
			condominio = _condominioService.Get(3);
			Assert.AreEqual("Paulo Coelho", condominio.Nome);
			Assert.AreEqual("1950-11-21", condominio.Cnpj);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_condominioService.Delete(2);
			// Assert
			Assert.AreEqual(2,_condominioService.GetAll().Count());
			var condominio = _condominioService.Get(2);
			Assert.AreEqual(null, condominio);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaCondominio = _condominioService.GetAll();
			// Assert
			Assert.IsInstanceOfType(listaCondominio, typeof(IEnumerable<Condominio>));
			Assert.IsNotNull(listaCondominio);
			Assert.AreEqual(3, listaCondominio.Count());
			Assert.AreEqual(1, listaCondominio.First().IdCondominio);
			Assert.AreEqual("Machado de Assis", listaCondominio.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var condominio = _condominioService.Get(1);
			Assert.IsNotNull(condominio);
			Assert.AreEqual("Machado de Assis", condominio.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var condominios = _condominioService.GetByName("Machado");
			Assert.IsNotNull(condominios);
			Assert.AreEqual(1, condominios.Count());
			Assert.AreEqual("Machado de Assis", condominios.First().Nome);
		}

		
		
	}

}