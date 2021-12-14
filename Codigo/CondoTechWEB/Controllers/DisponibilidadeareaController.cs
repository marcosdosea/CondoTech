using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
	[Authorize]
	public class DisponibilidadeareaController : Controller
    {
		private readonly IDisponibilidadeareaService _disponibilidadeareaService;
		private readonly IAreacomumService _areacomumService;
		private readonly IMapper _mapper;

		public DisponibilidadeareaController(IDisponibilidadeareaService disponibilidadeService, IAreacomumService areacomumService, IMapper mapper)
		{

			_disponibilidadeareaService = disponibilidadeService;
			_areacomumService = areacomumService;
			_mapper = mapper;
		}


		public ActionResult Index()
		{
			var listarDisponibilidadearea = _disponibilidadeareaService.GetAll();
			var listarDisponibilidadeareaModel = _mapper.Map<List<DisponibilidadeareaModel>>(listarDisponibilidadearea);
			return View(listarDisponibilidadeareaModel);
		}

		// GET: DisponibilidadeareaController/Details/5
		public ActionResult Details(int id)
		{
			Disponibilidadearea disponibilidadearea = _disponibilidadeareaService.Get(id);
			DisponibilidadeareaModel disponibilidadeareaModel = _mapper.Map<DisponibilidadeareaModel>(disponibilidadearea);
			return View(disponibilidadeareaModel);
		}

		// GET: DisponibilidadeareaController/Create
		public ActionResult Create()
		{
			IEnumerable<Areacomum> listaareacomum = _areacomumService.GetAll();
			ViewBag.IdAreaComum = new SelectList(listaareacomum, "IdAreaComum", "Nome", null);
			return View();
		}

		// POST: DisponibilidadeareaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]

		public ActionResult Create(DisponibilidadeareaModel disponibilidadeareaModel)
		{

			var disponibilidadearea = _mapper.Map<Disponibilidadearea>(disponibilidadeareaModel);
			_disponibilidadeareaService.Insert(disponibilidadearea);

			return RedirectToAction(nameof(Index));
		}

		// GET: DisponibilidadeareaController/Edit/5
		public ActionResult Edit(int id)
		{
			Disponibilidadearea disponibilidadearea = _disponibilidadeareaService.Get(id);
			DisponibilidadeareaModel disponibilidadeareaModel = _mapper.Map<DisponibilidadeareaModel>(disponibilidadearea);
			return View(disponibilidadeareaModel);
		}

		// POST: DisponibilidadeareaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, DisponibilidadeareaModel disponibilidadeareaModel)
		{
			if (ModelState.IsValid)
			{
				var disponibilidadearea = _mapper.Map<Disponibilidadearea>(disponibilidadeareaModel);
				_disponibilidadeareaService.Update(disponibilidadearea);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: DisponibilidadeareaController/Delete/5
		public ActionResult Delete(int id)
		{
			Disponibilidadearea disponibilidadearea = _disponibilidadeareaService.Get(id);
			DisponibilidadeareaModel disponibilidadeareaModel= _mapper.Map<DisponibilidadeareaModel>(disponibilidadearea);
			return View(disponibilidadeareaModel);
		}

		// POST: AreacomumController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, DisponibilidadeareaModel disponibilidadeareaModel)
		{
			_disponibilidadeareaService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
