using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using CondoTechWEB.Models;
using System.Collections.Generic;
using Core.Service;

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

     public ActionResult Index()
        {
            var listaCondominio = _condominioService.ObterTodos();
            var listaCondominiosModel = _mapper.Map<List<CondominioModel>(listaCondominio)>;
            return View(CondominioModel);

        }
     public ActionResult Details(int id)
        {
            Condominio condominio = _condominioService.BuscarCondominio(id);
            CondominioModel condominioModel = _mapper.Map < CondominioModel(Condominio) >;
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
                _condominioService.InserirCondominio(condominio);
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
                _condominioService.AlterarCondominio(condominio);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Condominio condominio = _condominioService.AlterarCondominio(id);
            CondominioModel condominioModel = _mapper.Map<CondominioModel>(condominio);
            return View(condominioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, CondominioModel condominioModel)
        {
            _condominioService.RemoverCondominio(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
