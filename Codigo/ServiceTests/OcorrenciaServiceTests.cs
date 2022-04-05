using Microsoft.VisualStudio.TestTools.UnitTesting;
using CondoTechWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace CondoTechWEB.Controllers.Tests
{
    [TestClass()]
    public class OcorrenciaServiceTests
    {
        private CondoTechContext _context;
        private IOcorrenciaService _ocorrenciaService;
    

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
			var ocorrencias = new List<Ocorrencias>
					{
						new Ocorrencias {IdOcorrencia = 1, Descricao="Ocorrencia 1",IdPessoa = 1,IdCondominio=1,IdTipoOcorrencia=1 },
						new Ocorrencias {IdOcorrencia = 2, Descricao="Ocorrencia 2",IdPessoa = 1,IdCondominio=1,IdTipoOcorrencia=1 },
						new Ocorrencias {IdOcorrencia = 3, Descricao="Ocorrencia 3",IdPessoa = 1,IdCondominio=1,IdTipoOcorrencia=1 },
					};

			_context.AddRange(ocorrencias);
			_context.SaveChanges();

			_ocorrenciaService = new OcorrenciaService(_context);
		}

		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_ocorrenciaService.Insert(new Ocorrencias { IdOcorrencia = 4, Descricao = "Ocorrencia 4", IdPessoa = 1, IdCondominio = 1, IdTipoOcorrencia = 1 });
			// Assert
			Assert.AreEqual(4, _ocorrenciaService.GetAll().Count());
			var ocorrencias = _ocorrenciaService.Get(4);
			Assert.AreEqual("Ocorrencia 4", ocorrencias.Descricao);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var ocorrencia = _ocorrenciaService.Get(3);
			ocorrencia.Descricao = "Ocorrencia 3 alterada";
			_ocorrenciaService.Update(ocorrencia);
			ocorrencia = _ocorrenciaService.Get(3);
			Assert.AreEqual("Cinema", ocorrencia.Descricao);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_ocorrenciaService.Delete(2);
			// Assert
			Assert.AreEqual(2, _ocorrenciaService.GetAll().Count());
			var ocorrencia = _ocorrenciaService.Get(2);
			Assert.AreEqual(null, ocorrencia);
		}
		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaOcorrencias = _ocorrenciaService.GetAll();
			// Assert
			Assert.IsInstanceOfType(listaOcorrencias, typeof(IEnumerable<Areacomum>));
			Assert.IsNotNull(listaOcorrencias);
			Assert.AreEqual(3, listaOcorrencias.Count());
			Assert.AreEqual(1, listaOcorrencias.First().IdOcorrencia);
			Assert.AreEqual("Ocorrencia 1", listaOcorrencias.First().Descricao);
		}
		[TestMethod()]
		public void ObterTest()
		{
			var ocorrencia = _ocorrenciaService.Get(1);
			Assert.IsNotNull(ocorrencia);
			Assert.AreEqual("Ocorrencia 1", ocorrencia.Descricao);
		}

	}
}