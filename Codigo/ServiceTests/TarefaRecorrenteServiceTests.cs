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
    public class TarefaRecorrenteServiceTests
    {
        private CondoTechContext _context;
        private ITarefaRecorrenteService _tarefaRecorrenteService;
        private TarefaRecorrenteService _tarefaRecorenteService;

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
            var autores = new List<Tarefarecorrente>
                {
                    new Tarefarecorrente { IdTarefaRecorrente = 1, Nome = "Reunião amanhã", Descricao = "Reunião acerca do sistema de vigilância"},
                    new Tarefarecorrente { IdTarefaRecorrente = 2, Nome = "Reunião financeira amanhã", Descricao = "Reunião acerca da taxa de condomínio"},
                    new Tarefarecorrente { IdTarefaRecorrente = 3, Nome = "Reunião Importante!", Descricao = "Reunião sobre sujeira em áreas comuns"},
                };

            _context.AddRange(autores);
            _context.SaveChanges();

            _tarefaRecorenteService = new TarefaRecorrenteService(_context);
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _tarefaRecorenteService.Insert(new Tarefarecorrente() { IdTarefaRecorrente = 4, Nome = "Reunião amanhã", Descricao = "12312343212" });
            // Assert
            Assert.AreEqual(4, _tarefaRecorenteService.GetAll().Count());
            var tarefarecorrente = _tarefaRecorenteService.Get(4);
            Assert.AreEqual("Reunião amanhã", tarefarecorrente.Nome);
            Assert.AreEqual("12312343212", tarefarecorrente.Descricao);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var tarefarecorrente = _tarefaRecorenteService.Get(3);
            tarefarecorrente.Nome = "Reunião amanhã";
            tarefarecorrente.Descricao = "98798798767";
            _tarefaRecorenteService.Update(tarefarecorrente);
            tarefarecorrente = _tarefaRecorenteService.Get(3);
            Assert.AreEqual("Reunião amanhã", tarefarecorrente.Nome);
            Assert.AreEqual("98798798767", tarefarecorrente.Descricao);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _tarefaRecorenteService.Delete(2);
            // Assert
            Assert.AreEqual(2, _tarefaRecorenteService.GetAll().Count());
            var tarefarecorrente = _tarefaRecorenteService.Get(2);
            Assert.AreEqual(null, tarefarecorrente);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaAutor = _tarefaRecorenteService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Tarefarecorrente>));
            Assert.IsNotNull(listaAutor);
            Assert.AreEqual(3, listaAutor.Count());
            Assert.AreEqual(1, listaAutor.First().IdTarefaRecorrente);
            Assert.AreEqual("Reunião amanhã", listaAutor.First().Nome);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var tarefarecorrente = _tarefaRecorenteService.Get(1);
            Assert.IsNotNull(tarefarecorrente);
            Assert.AreEqual("Reunião amanhã", tarefarecorrente.Nome);
        }

    }
}