﻿using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using System.Collections.Generic;
using Core.Service;
using System;

namespace CondoTechWEB.Controllers
{
    public class CondominioController : Controller
    {
        ICondominioService _condominioService;
        IMapper _mapper;

    public CondominioController(ICondominioService condominioService, IMapper mapper)
        {
            _condominioService = condominioService;
            _mapper = mapper;
        }

    //comentei para testes dia 09/11/2021
     /*public ActionResult Index()
        {
            var listaCondominio = _condominioService.ObterTodos();
            var listaCondominiosModel = _mapper.Map<List<CondominioModel>(listaCondominio);
            return View(CondominioModel);

        }*/
    public ActionResult Details(int id)
    {
        Condominio condominio = _condominioService.Get(id);
        CondominioModel condominioModel = _mapper.Map<CondominioModel>(condominio);
        return View(condominioModel);
    }

     public ActionResult Create()
        {
            return View();
        }


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

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, CondominioModel condominioModel)
        {
            if (ModelState.IsValid)
            {
                var condominio = _mapper.Map<Condominio>(condominioModel);
                _condominioService.Update(condominio);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

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
