using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using Core.Service;
using CondoTechWEB.Mappers;
using Mappers;
using System;

namespace CondoTechWEB.Controllers.Tests
{
    [TestClass()]
    public class AvisoControllerTests
    {
        private static AvisoController controller;


        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IAvisoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AvisosProfile())).CreateMapper();

            mockService.Setup(service => service.obterTodosAvisos())
                .Returns(GetTestAviso());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAviso());
            mockService.Setup(service => service.Update(It.IsAny<Aviso>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Aviso>()))
                .Verifiable();
            controller = new AvisoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AvisoModel>));
            List<AvisoModel> lista = (List<AvisoModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvisoModel));
            AvisoModel avisoModel = (AvisoModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, avisoModel.IdAviso);
            Assert.AreEqual("Assembléia deliberativa sobre problemas no novo sistema", avisoModel.Descricao);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewAviso());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("IdAviso", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAviso());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvisoModel));
            AvisoModel avisoModel = (AvisoModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, avisoModel.IdAviso);
            Assert.AreEqual("Assembléia deliberativa sobre problemas no novo sistema", avisoModel.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetAvisoModel().IdAviso, GetTargetAvisoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvisoModel));
            AvisoModel avisoModel = (AvisoModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, avisoModel.IdAviso);
            Assert.AreEqual("Assembléia deliberativa sobre problemas no novo sistema", avisoModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAvisoModel().IdAviso, GetTargetAvisoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        
        private static AvisoModel GetNewAviso()
        {
            return new AvisoModel
            {
                IdAviso = 4,
                Descricao = "Favor comparecer à administração para resolver as pendências",
                idCondominio = 1,
                idPessoa = 1
            };
        }
        private static Aviso GetTargetAviso()
        {
            return new Aviso
            {
                idAviso = 1,
                descricao = "Assembléia deliberativa sobre problemas no novo sistema",
                idPessoa = 1,
                idCondominio = 1
            };
        }
        private static AvisoModel GetTargetAvisoModel()
        {
            return new AvisoModel
            {
                IdAviso = 2,
                Descricao = "Assembléia para decisão da nova chapa",
                idPessoa = 2,
                idCondominio = 1
            };
        }

        private static IEnumerable<Aviso> GetTestAviso()
        {
            return new List<Aviso>
            {
                new Aviso
                {
                    idAviso = 1,
                    descricao = "Assembléia as 19:30",
                    idPessoa = 2,
                    idCondominio = 1
                },
                new Aviso
                {
                    idAviso = 2,
                    descricao = "Assembléia as 18:30",
                    idPessoa = 3,
                    idCondominio = 1
                },
                new Aviso
                {
                    idAviso = 3,
                    descricao = "Assembléia as 20:30",
                    idPessoa = 3,
                    idCondominio = 1
                },
            };
        }

    }
}