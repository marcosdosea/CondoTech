using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
    public class OcorrenciaController : Controller
    {
        IOcorrenciaService _ocorrenciaService;
        IMapper _mapper;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, IMapper mapper)
        {
            _ocorrenciaService = ocorrenciaService;
            _mapper = mapper;
        }

        // GET: OcorrenciaController1
        public ActionResult Index()
        {
            var listaOcorrencias = _ocorrenciaService.GetAll();
            var listaOcorrenciasModel = _mapper.Map<List<OcorrenciaModel>>(listaOcorrencias);
            return View(listaOcorrenciasModel);
        }

        // GET: OcorrenciaController1/Details/5
        public ActionResult Details(int id)
        {
            Ocorrencias ocorrencia = _ocorrenciaService.Get(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            return View(ocorrenciaModel);
        }

        // GET: OcorrenciaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OcorrenciaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OcorrenciaModel ocorrenciaModel)
        {
           if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencias>(ocorrenciaModel);
                _ocorrenciaService.Insert(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController1/Edit/5
        public ActionResult Edit(int id)
        {
            Ocorrencias ocorrencia = _ocorrenciaService.Get(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            return View(ocorrenciaModel);
        }

        // POST: OcorrenciaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OcorrenciaModel ocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencias>(ocorrenciaModel);
                _ocorrenciaService.Update(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController1/Delete/5
        public ActionResult Delete(int id)
        {
            Ocorrencias ocorrencia = _ocorrenciaService.Get(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            return View(ocorrenciaModel);
        }

        // POST: OcorrenciaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _ocorrenciaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
