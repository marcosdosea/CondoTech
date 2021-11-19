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
	public class PessoaControllerTests
	{
		private static PessoaController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IPessoaService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new PessoaProfile())).CreateMapper();

			mockService.Setup(service => service.GetAll())
				.Returns(GetTestPessoas());
			mockService.Setup(service => service.Get(1))
				.Returns(GetTargetPessoa());
			mockService.Setup(service => service.Update(It.IsAny<Pessoa>()))
				.Verifiable();
			mockService.Setup(service => service.Insert(It.IsAny<Pessoa>()))
				.Verifiable();
			controller = new PessoaController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));
			List<PessoaModel> lista = (List<PessoaModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme", pessoaModel.Nome);
			Assert.AreEqual("12345678909", pessoaModel.Cpf);
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
			var result = controller.Create(GetNewPessoa());

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
			var result = controller.Create(GetNewPessoa());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme", pessoaModel.Nome);
			Assert.AreEqual("12345678909", pessoaModel.Cpf);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(GetTargetPessoaModel().IdPessoa, GetTargetPessoaModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme", pessoaModel.Nome);
			Assert.AreEqual("12345678909", pessoaModel.Cpf);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetPessoaModel().IdPessoa, GetTargetPessoaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static PessoaModel GetNewPessoa()
		{
			return new PessoaModel
			{
				IdPessoa = 4,
				Nome = "Raul Carira",
				Cpf = "12121212121"
			};

		}
		private static Pessoa GetTargetPessoa()
		{
			return new Pessoa
			{
				IdPessoa = 1,
				Nome = "Guilherme",
				Cpf = "12345678909"
			};
		}

		private static PessoaModel GetTargetPessoaModel()
		{
			return new PessoaModel
			{
				IdPessoa = 2,
				Nome = "Guilherme",
				Cpf = "12345678909"
			};
		}

		private static IEnumerable<Pessoa> GetTestPessoas()
		{
			return new List<Pessoa>
			{
				new Pessoa
				{
					IdPessoa = 1,
					Nome = "Guilherme",
					Cpf = "09090909098"
				},
				new Pessoa
				{
					IdPessoa = 2,
					Nome = "Raul",
					Cpf = "12312312312"
				},
				new Pessoa
				{
					IdPessoa = 3,
					Nome = "Rafael",
					Cpf = "23423423423"
				},
			};
		}
	}
}