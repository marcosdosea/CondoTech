using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
    public class AreacomumController : Controller
    {
		private readonly IAreacomumService _areacomumService;
		private readonly IMapper _mapper;

		public AreacomumController(IAreacomumService areacomumService, IMapper mapper)
		{
			_areacomumService = areacomumService;
			_mapper = mapper;
		}


		// GET: AreacomumController/Details/5
		public ActionResult Details(int id)
		{
			Areacomum areacomum = _areacomumService.Buscar(id);
			AreacomumModel areacomumModel = _mapper.Map<AreacomumModel>(areacomum);
			return View(areacomumModel);
		}

		// GET: AreacomumController/Create
		[Authorize]
		public ActionResult Create()
		{
			return View();
		}

		// POST: AreacomumController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AreacomumModel areacomumModel)
		{
			if (ModelState.IsValid)
			{
				var areacomum = _mapper.Map<Areacomum>(areacomumModel);
				_areacomumService.Inserir(areacomum);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AreacomumController/Edit/5
		public ActionResult Edit(int id)
		{
			Areacomum areacomum = _areacomumService.Buscar(id);
			AreacomumModel areacomumModel = _mapper.Map<AreacomumModel>(areacomum);
			return View(areacomumModel);
		}

		// POST: AreacomumController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, AreacomumModel areacomumModel)
		{
			if (ModelState.IsValid)
			{
				var areacomum = _mapper.Map<Areacomum>(areacomumModel);
				_areacomumService.Alterar(areacomum);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AreacomumController/Delete/5
		public ActionResult Delete(int id)
		{
			Areacomum areacomum = _areacomumService.Buscar(id);
			AreacomumModel areacomumModel = _mapper.Map<AreacomumModel>(areacomum);
			return View(areacomumModel);
		}

		// POST: AreacomumController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AreacomumModel areacomumModel)
		{
			_areacomumService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
