using Microsoft.VisualStudio.TestTools.UnitTesting;
using CondoTechWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core;
using AutoMapper;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using Core.Service;
using CondoTechWEB.Mappers;

namespace CondoTechWEB.Controllers.Tests
{
    [TestClass()]
    public class CondominioControllerTests
    {
        private static CondominioController controller;



        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            var mockService = new Mock<ICondominioService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new CondominioProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestCondominios());

            mockService.Setup(service => service.Get(1)).Returns(GetTargetCondominio());

            mockService.Setup(service => service.Update(It.IsAny<Condominio>())).Verifiable();

            mockService.Setup(service => service.Insert(It.IsAny<Condominio>())).Verifiable();

            controller = new CondominioController(mockService.Object, mapper);
        }




		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CondominioModel>));
			List<CondominioModel> lista = (List<CondominioModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CondominioModel));
			CondominioModel condominioModel = (CondominioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado", condominioModel.Nome);
			Assert.AreEqual("01.666.126/0009-44", condominioModel.Cnpj);
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
			var result = controller.Create(GetNewCondominio());

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
			var result = controller.Create(GetNewCondominio());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CondominioModel));
			CondominioModel condominioModel = (CondominioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado", condominioModel.Nome);
			Assert.AreEqual("01.666.126/0009-44", condominioModel.Cnpj);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(GetTargetCondominioModel().IdCondominio, GetTargetCondominioModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CondominioModel));
			CondominioModel condominioModel = (CondominioModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado", condominioModel.Nome);
			Assert.AreEqual("01.666.126/0009-44", condominioModel.Cnpj);
		}



		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetCondominioModel().IdCondominio, GetTargetCondominioModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static CondominioModel GetNewCondominio()
		{
			return new CondominioModel
			{
				IdCondominio = 4,
				Nome = "Ian Sommerville",
				Cnpj = "05.777.111/0002-48"
			};

		}
		private static Condominio GetTargetCondominio()
		{
			return new Condominio
			{
				IdCondominio = 1,
				Nome = "Machado",
				Cnpj = "01.666.126/0009-44"
			};
		}

		private static CondominioModel GetTargetCondominioModel()
		{
			return new CondominioModel
			{
				IdCondominio = 2,
				Nome = " de Assis",
				Cnpj = "04.775.130/0001-49"
			};
		}

		private static IEnumerable<Condominio> GetTestCondominios()
		{
			return new List<Condominio>
			{
				new Condominio
				{
					IdCondominio = 1,
					Nome = "Graciliano Ramos",
					Cnpj = "03.778.130/0001-48"
				},
				new Condominio
				{
					IdCondominio = 2,
					Nome = "Machado de Assis",
					Cnpj = "03.772.130/0001-48"
				},
				new Condominio
				{
					IdCondominio = 3,
					Nome = "Marcos Ramos",
					Cnpj = "03.780.130/0001-48"

				},
			};
		}
	}
}


