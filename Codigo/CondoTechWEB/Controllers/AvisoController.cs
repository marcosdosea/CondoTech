using System;
using System.Collections.Generic;
using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoTechWEB.Controllers
{
    [Authorize]
    public class AvisoController : Controller
    {

        private readonly IAvisoService _avisoService;
        private readonly IMapper _mapper;

        public AvisoController(IAvisoService avisoService, IMapper mapper)
        {
            _avisoService = avisoService;
            _mapper = mapper;
        }

        // GET: AvisoController
        public ActionResult Index()
        {
            var listarAvisos = _avisoService.obterTodosAvisos();
            var listarTarefasRecorrentesModel = _mapper.Map<List<AvisoModel>>(listarAvisos);
            return View(listarTarefasRecorrentesModel);
        }

        // GET: AvisoController/Details/5
        public ActionResult Details(int id)
        {
            Aviso aviso = _avisoService.Get(id);
            AvisoModel avisoModel = _mapper.Map<AvisoModel>(aviso);
            return View(avisoModel);
        }

        // GET: AvisoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvisoModel avisoModel)
        {
                if (ModelState.IsValid)
                {
                    Aviso aviso = _mapper.Map<Aviso>(avisoModel);
                    _avisoService.Insert(aviso);
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: AvisoController/Edit/5
        public ActionResult Edit(int id)
        {
            Aviso aviso = _avisoService.Get(id);
            AvisoModel avisoModel = _mapper.Map<AvisoModel>(aviso);
            return View(avisoModel);
        }

        // POST: AvisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AvisoModel avisoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aviso = _mapper.Map<Aviso>(avisoModel);
                    aviso.idAviso = id;
                    _avisoService.Update(aviso);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AvisoController/Delete/5
        public ActionResult Delete(int id)
        {
            Aviso aviso = _avisoService.Get(id);
            AvisoModel avisoModel = _mapper.Map<AvisoModel>(aviso);
            return View(avisoModel);
        }

        // POST: AvisoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvisoModel avisoModel)
        {
                Aviso aviroRecebido = _avisoService.Get(id);
                _avisoService.Delete(id,aviroRecebido.idPessoa,aviroRecebido.idCondominio);
                return RedirectToAction(nameof(Index));
        }
    }
}
