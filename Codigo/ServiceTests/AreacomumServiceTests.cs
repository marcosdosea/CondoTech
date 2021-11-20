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
		public class AreacomumServiceTests
		{
			private CondoTechContext _context;
			private IAreacomumService _areacomumService;

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
				var areascomums = new List<Areacomum>
				{
					new Areacomum { IdAreaComum = 1, IdCondominio = 1, Nome = "Piscina", Descricao = "Piscina para crianças"},
					new Areacomum { IdAreaComum = 2, IdCondominio = 1, Nome = "Pula-pula", Descricao = "Pula-pula para crianças"},
					new Areacomum { IdAreaComum = 3, IdCondominio = 1, Nome = "Cinema", Descricao = "Cinema para os condôminos em geral"},
				};

				_context.AddRange(areascomums);
				_context.SaveChanges();

				_areacomumService = new AreacomumService(_context);
			}


			[TestMethod()]
			public void InserirTest()
			{
				// Act
				_areacomumService.Insert(new Areacomum() { IdAreaComum = 4, IdCondominio = 1, Nome = "Quadra poliesportiva", Descricao = "Quadra para a prática de diversos esportes" });
				// Assert
				Assert.AreEqual(4, _areacomumService.GetAll().Count());
				var areacomum = _areacomumService.Get(4);
				Assert.AreEqual("Quadra poliesportiva", areacomum.Nome);
			}

			[TestMethod()]
			public void EditarTest()
			{
				var areacomum = _areacomumService.Get(3);
				areacomum.Nome = "Cinema";
				_areacomumService.Update(areacomum);
				areacomum = _areacomumService.Get(3);
				Assert.AreEqual("Cinema", areacomum.Nome);
			}

			[TestMethod()]
			public void RemoverTest()
			{
				// Act
				_areacomumService.Delete(2);
				// Assert
				Assert.AreEqual(2, _areacomumService.GetAll().Count());
				var areacomum = _areacomumService.Get(2);
				Assert.AreEqual(null, areacomum);
			}

			[TestMethod()]
			public void ObterTodosTest()
			{
				// Act
				var listaAreacomum = _areacomumService.GetAll();
				// Assert
				Assert.IsInstanceOfType(listaAreacomum, typeof(IEnumerable<Areacomum>));
				Assert.IsNotNull(listaAreacomum);
				Assert.AreEqual(3, listaAreacomum.Count());
				Assert.AreEqual(1, listaAreacomum.First().IdAreaComum);
				Assert.AreEqual("Piscina", listaAreacomum.First().Nome);
			}


			[TestMethod()]
			public void ObterTest()
			{
				var areacomum = _areacomumService.Get(1);
				Assert.IsNotNull(areacomum);
				Assert.AreEqual("Piscina", areacomum.Nome);
			}

			[TestMethod()]
			public void ObterPorNomeTest()
			{
				var areascomuns = _areacomumService.GetByName("Piscina");
				Assert.IsNotNull(areascomuns);
				Assert.AreEqual(1, areascomuns.Count());
				Assert.AreEqual("Piscina", areascomuns.First().Nome);
			}


		}
	
}