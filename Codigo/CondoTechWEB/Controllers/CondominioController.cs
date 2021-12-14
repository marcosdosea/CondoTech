using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using System.Collections.Generic;
using Core.Service;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CondoTechWEB.Controllers
{
    [Authorize]
    public class CondominioController : Controller
    {
        private readonly ICondominioService _condominioService;
        private readonly IMapper _mapper;

    public CondominioController(ICondominioService condominioService, IMapper mapper)
        {
            _condominioService = condominioService;
            _mapper = mapper;
        }
     // GET: CondominioController
        public ActionResult Index()
        {
            var listaCondominio = _condominioService.GetAll();
            var listaCondominiosModel = _mapper.Map<List<CondominioModel>>(listaCondominio);
            return View(listaCondominiosModel);

        }
    // GET: TarefaRecorrenteController/Details/
        public ActionResult Details(int id)
    {
        Condominio condominio = _condominioService.Get(id);
        CondominioModel condominioModel = _mapper.Map<CondominioModel>(condominio);
        return View(condominioModel);
    }

     //GET: CondominioController/Create
        public ActionResult Create()
        {
            return View();
        }
     // POST: CondominioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CondominioModel condominioModel)
        {
            if (ModelState.IsValid)
            {
                var condominio = _mapper.Map<Condominio>(condominioModel);
                _condominioService.Insert(condominio);
            }
            return RedirectToAction(nameof(Index));
        }

        
        public ActionResult Edit (int id)
        {
            Condominio condominio = _condominioService.Get(id);
            CondominioModel condominioModel = _mapper.Map<CondominioModel>(condominio);
            return View(condominioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: CondominioController/Edit/

        public ActionResult Edit(int id, CondominioModel condominioModel)
        {

            if (ModelState.IsValid)
            {

                var condominio = _mapper.Map<Condominio>(condominioModel);
                _condominioService.Update(condominio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CondomonioController/Delete
        public ActionResult Delete(int id)
        {
            Condominio condominio = _condominioService.Get(id);
            CondominioModel condominioModel = _mapper.Map<CondominioModel>(condominio);
            return View(condominioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, CondominioModel condominioModel)
        {
            _condominioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
