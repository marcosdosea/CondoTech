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
    public class DisponibilidadeareaTests
    {
        private static DisponibilidadeareaController controller;

        [ClassInitialize]

        public static void Initialize(TestContext testContext)
        {
            var mockService = new Mock<IDisponibilidadeareaService>();

            


            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new DisponibilidadeareaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestDisponibilidadearea());

            mockService.Setup(service => service.Get(1)).Returns(GetTargetDisponibilidadearea());

            mockService.Setup(service => service.Update(It.IsAny<Disponibilidadearea>())).Verifiable();

            mockService.Setup(service => service.Insert(It.IsAny<Disponibilidadearea>())).Verifiable();


            controller = new DisponibilidadeareaController(mockService.Object, mapper);

        }

        private static IEnumerable<Disponibilidadearea> GetTestDisponibilidadearea()
        {
            return new List<Disponibilidadearea>
            {
                new Disponibilidadearea
                {
                    IdDisponibilidadeArea = 1,
                    IdAreaComum = 1,

                },

                new Disponibilidadearea
                {
                    IdDisponibilidadeArea = 2,
                    IdAreaComum = 1,

                },

                new Disponibilidadearea
                {
                    IdDisponibilidadeArea = 3,
                    IdAreaComum = 2
                }

            };
        }

        private static Disponibilidadearea GetTargetDisponibilidadearea()
        {
            return new Disponibilidadearea
            {
                IdDisponibilidadeArea = 1,
                IdAreaComum = 1,
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DisponibilidadeareaModel>));
            List<DisponibilidadeareaModel> listaDisponibilidadearea = (List<DisponibilidadeareaModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, listaDisponibilidadearea.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilidadeareaModel));
            DisponibilidadeareaModel disponibilidadeareaModel = (DisponibilidadeareaModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, disponibilidadeareaModel.IdDisponibilidadeArea);
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
            var result = controller.Create(GetNewDisponibilidadearea());

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
            controller.ModelState.AddModelError("Id", "Campo requerido");

            // Act
            var result = controller.Create(GetNewDisponibilidadearea());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilidadeareaModel));
            DisponibilidadeareaModel disponibilidadeareaModel = (DisponibilidadeareaModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, disponibilidadeareaModel);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetDisponibilidadearea().IdDisponibilidadeArea, GetTargetDisponibilidadeModel());

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
            DisponibilidadeareaModel disponibilidadeareaModel = (DisponibilidadeareaModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, disponibilidadeareaModel);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetDisponibilidadeModel().IdDisponibilidadeArea, GetTargetDisponibilidadeModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static DisponibilidadeareaModel GetNewDisponibilidadearea()
        {
            return new DisponibilidadeareaModel
            {
                IdAreaComum = 1,
                IdDisponibilidadeArea = 1,

            };

        }


        private static DisponibilidadeareaModel GetTargetDisponibilidadeModel()
        {
            return new DisponibilidadeareaModel
            {
                IdAreaComum = 2,
                IdDisponibilidadeArea = 1,
            };
        }
    }
}