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
    public class AvisoServiceTests
    {

        private CondoTechContext _context;
        private IAvisoService _avisoService;

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
            var pessoas = new List<Aviso>
                {
                    new Aviso { idAviso = 1, descricao = "Assembléia às 18:30", idPessoa = 1, idCondominio = 1},
                    new Aviso { idAviso = 2, descricao = "Assembléia às 19:30", idPessoa = 2, idCondominio = 1},
                    new Aviso { idAviso = 3, descricao = "Assembléia às 20:30", idPessoa = 3, idCondominio = 1},
                };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _avisoService = new AvisoService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _avisoService.Insert(new Aviso() { idAviso = 4, descricao = "Assembléia às 21:00", idPessoa = 1, idCondominio = 1});
            // Assert
            Assert.AreEqual(4, _avisoService.obterTodosAvisos().Count());
            var aviso = _avisoService.Get(4);
            Assert.AreEqual(4, aviso.idAviso);
            Assert.AreEqual("Assembléia às 21:00", aviso.descricao);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var aviso = _avisoService.Get(3);
            aviso.descricao = "Reunião para nova chapa";
            _avisoService.Update(aviso);
            aviso = _avisoService.Get(3);
            Assert.AreEqual("Reunião para nova chapa", aviso.descricao);
        }

        [TestMethod()]
        public void GetTest()
        {
            var aviso = _avisoService.Get(1);
            Assert.IsNotNull(aviso);
            Assert.AreEqual("Assembléia às 18:30", aviso.descricao);
        }

        [TestMethod()]
        public void obterTodosAvisosTest()
        {
            // Act
            var listaAviso = _avisoService.obterTodosAvisos();
            // Assert
            Assert.IsInstanceOfType(listaAviso, typeof(IEnumerable<Aviso>));
            Assert.IsNotNull(listaAviso);
            Assert.AreEqual(3, listaAviso.Count());
            Assert.AreEqual(1, listaAviso.First().idAviso);
            Assert.AreEqual("Assembléia às 18:30", listaAviso.First().descricao);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _avisoService.Delete(2, 1, 1);
            // Assert
            Assert.AreEqual(2, _avisoService.obterTodosAvisos().Count());
            var aviso = _avisoService.Get(2);
            Assert.AreEqual(null, aviso);
        }
    }
}