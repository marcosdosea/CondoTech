using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using Core.Service;
using CondoTechWEB.Mappers;

namespace CondoTechWEB.Controllers.Tests
{
    [TestClass()]
    public class AreacomumControllerTests
    {

        private static AreacomumController controller;

        [ClassInitialize]

        public static void Initialize(TestContext testContext)
        {
            var mockService = new Mock<IAreacomumService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AreacomumProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestAreacomum());

            mockService.Setup(service => service.Get(1)).Returns(GetTargetAreacomum());

            mockService.Setup(service => service.Update(It.IsAny<Areacomum>())).Verifiable();

            mockService.Setup(service => service.Insert(It.IsAny<Areacomum>())).Verifiable();

            controller = new AreacomumController(mockService.Object, mapper);

        }

        private static IEnumerable<Areacomum>GetTestAreacomum()
        {
            return new List<Areacomum>
            {
                new Areacomum
                {
                    IdAreaComum = 1,
                    IdCondominio = 1,
                    Nome = "Quadra de volei",
                    Descricao = "Quadra de volei com iluminação noturna"

                },

                new Areacomum
                {
                    IdAreaComum = 2,
                    IdCondominio = 1,
                    Nome = "Piscina",
                    Descricao = "Perfeita para adultos"

                },

                new Areacomum
                {
                    IdAreaComum = 3,
                    IdCondominio = 1,
                    Nome = "Campo de futebol infantil",
                    Descricao = "Campo de futebol focado para crianças, com dimensões reduzidas"

                },


            };
        }

        private static Areacomum GetTargetAreacomum()
        {
            return new Areacomum
            {
                IdAreaComum = 1,
                IdCondominio = 1,
                Nome = "Quadra de volei",
                Descricao = "Quadra de volei com iluminação noturna"

            };
        }


        [TestMethod()]
        public void IndexTest()
        {
            // act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AreacomumModel>));
            List<AreacomumModel> listaAreacomum = (List<AreacomumModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, listaAreacomum.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreacomumModel));
            AreacomumModel areacomumModel = (AreacomumModel)viewResult.ViewData.Model;
            Assert.AreEqual("Quadra de volei", areacomumModel.Nome);
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
            var result = controller.Create(GetNewAreacomum());

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
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAreacomum());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreacomumModel));
            AreacomumModel areacomumModel = (AreacomumModel)viewResult.ViewData.Model;
            Assert.AreEqual("Quadra de volei", areacomumModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetAreacomumModel().IdAreaComum, GetTargetAreacomumModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreacomumModel));
            AreacomumModel areacomumModel = (AreacomumModel)viewResult.ViewData.Model;
            Assert.AreEqual("Quadra de volei", areacomumModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAreacomumModel().IdAreaComum, GetTargetAreacomumModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static AreacomumModel GetNewAreacomum()
        {
            return new AreacomumModel
            {
                IdAreaComum = 1,
                IdCondominio = 1,
                Nome = "Quadra de volei",
                Descricao = "Quadra de volei com iluminação noturna"
            };

        }


        private static AreacomumModel GetTargetAreacomumModel()
        {
            return new AreacomumModel
            {
                IdAreaComum = 2,
                IdCondominio = 1,
                Nome = "Piscina",
                Descricao = "Perfeita para adultos"
            };
        }
    }
}