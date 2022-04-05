using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using Core.Service;
using CondoTechWEB.Mappers;
using System;

namespace CondoTechWEB.Controllers.Tests
{
    [TestClass()]
    public class TarefaRecorrenteControllerTests
    {
        private static TarefaRecorrenteController controller;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<ITarefaRecorrenteService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new TarefaRecorrenteProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestTarefaRecorrente());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetTarefaRecorrente());
            mockService.Setup(service => service.Update(It.IsAny<Tarefarecorrente>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Tarefarecorrente>()))
                .Verifiable();
            controller = new TarefaRecorrenteController(mockService.Object, mapper);
        }

       


        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TarefaRecorrenteModel>));
            List<TarefaRecorrenteModel> lista = (List<TarefaRecorrenteModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TarefaRecorrenteModel));
            TarefaRecorrenteModel tarefaRecorrenteModel = (TarefaRecorrenteModel)viewResult.ViewData.Model;
            Assert.AreEqual("Reunião amanhã", tarefaRecorrenteModel.Nome);
            Assert.AreEqual("Reunião com todos os condôminos à noite", tarefaRecorrenteModel.Descricao);
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
            var result = controller.Create(GetNewTarefaRecorrente());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewTarefaRecorrente());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TarefaRecorrenteModel));
            TarefaRecorrenteModel tarefaRecorrenteModel = (TarefaRecorrenteModel)viewResult.ViewData.Model;
            Assert.AreEqual("Reunião mês que vem", tarefaRecorrenteModel.Nome);
            Assert.AreEqual("Reunião Importante!", tarefaRecorrenteModel.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetTarefaRecorrenteModel().IdTarefaRecorrente, GetTargetTarefaRecorrenteModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TarefaRecorrenteModel));
            TarefaRecorrenteModel tarefaRecorrenteModel = (TarefaRecorrenteModel)viewResult.ViewData.Model;
            Assert.AreEqual("Reunião amanhã", tarefaRecorrenteModel.Nome);
            Assert.AreEqual("Reunião com todos os condôminos à noite", tarefaRecorrenteModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetTarefaRecorrenteModel().IdTarefaRecorrente, GetTargetTarefaRecorrenteModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static IEnumerable<Tarefarecorrente> GetTestTarefaRecorrente()
        {
            return new List<Tarefarecorrente>
            {
                new Tarefarecorrente
                {
                    IdTarefaRecorrente = 1,
                    Nome = "Reunião amanhã",
                    Descricao = "Reunião acerca do sistema de vigilância"
                },
                new Tarefarecorrente
                {
                    IdTarefaRecorrente = 2,
                    Nome = "Reunião financeira amanhã",
                    Descricao = "Reunião acerca da taxa de condomínio"
                },
                new Tarefarecorrente
                {
                    IdTarefaRecorrente = 3,
                    Nome = "Reunião Importante!",
                    Descricao = "Reunião sobre sujeira em áreas comuns"
                },
            };
        }

        private static Tarefarecorrente GetTargetTarefaRecorrente()
        {
            return new Tarefarecorrente
            {
                IdTarefaRecorrente = 2,
                Nome = "Reunião financeira amanhã",
                Descricao = "Reunião acerca da taxa de condomínio"
            };
            
        }
        private static TarefaRecorrenteModel GetTargetTarefaRecorrenteModel()
        {
            return new TarefaRecorrenteModel
            {
                IdTarefaRecorrente = 1,
                Nome = "Reunião amanhã",
                Descricao = "Reunião acerca do sistema de vigilância"
            };
        }
        private TarefaRecorrenteModel GetNewTarefaRecorrente()
        {
            return new TarefarecorrenteModel
            {
                IdTarefaRecorrente = 1,
                Nome = "Reunião amanhã",
                Descricao = "Reunião acerca do sistema de vigilância"
            };
        }
    }
}