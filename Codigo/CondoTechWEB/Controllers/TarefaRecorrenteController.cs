using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
    public class TarefaRecorrenteController : Controller
    {

        private readonly ITarefaRecorrenteService _tarefarecorrenteService;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public TarefaRecorrenteController(ITarefaRecorrenteService tarefarecorrenteService, IPessoaService pessoaService, IMapper mapper)
        {
            _tarefarecorrenteService = tarefarecorrenteService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: TarefaRecorrenteController
        public ActionResult Index()
        {
            var listarTarefasRecorrentes = _tarefarecorrenteService.GetAll();
            var listarTarefasRecorrentesModel = _mapper.Map<List<TarefaRecorrenteModel>>(listarTarefasRecorrentes);

            return View(listarTarefasRecorrentesModel);
        }



        // GET: TarefaRecorrenteController/Details/5
        public ActionResult Details(int id)
        {
            Tarefarecorrente tarefarecorrente = _tarefarecorrenteService.Buscar(id);
            TarefaRecorrenteModel tarefaRecorrenteModel = _mapper.Map<TarefaRecorrenteModel>(tarefarecorrente);
            return View(tarefaRecorrenteModel);
        }

        // GET: TarefaRecorrenteController/Create
        public ActionResult Create()
        {
            IEnumerable<Pessoa> listapessoas = _pessoaService.GetAll();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);
            return View();
        }

        // POST: TarefaRecorrenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarefaRecorrenteModel tarefaRecorrenteModel)
        {
            /*var tarefarecorrente = _mapper.Map<Tarefarecorrente>(tarefaRecorrenteModel);
            _tarefarecorrenteService.Inserir(tarefarecorrente);
            return RedirectToAction(nameof(Index));*/
            if (ModelState.IsValid)
            {
                var tarefarecorrente = _mapper.Map<Tarefarecorrente>(tarefaRecorrenteModel);
                _tarefarecorrenteService.Inserir(tarefarecorrente);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TarefaRecorrenteController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Pessoa> listapessoas = _pessoaService.GetAll();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);

            Tarefarecorrente tarefarecorrente = _tarefarecorrenteService.Buscar(id);
            TarefaRecorrenteModel tarefaRecorrenteModel = _mapper.Map<TarefaRecorrenteModel>(tarefarecorrente);

            return View(tarefaRecorrenteModel);
        }

        // POST: TarefaRecorrenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TarefaRecorrenteModel tarefaRecorrenteModel)
        {
            if (ModelState.IsValid)
            {
                var tarefarecorrente = _mapper.Map<Tarefarecorrente>(tarefaRecorrenteModel);

                tarefarecorrente.IdTarefaRecorrente = id;
                _tarefarecorrenteService.Alterar(tarefarecorrente);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TarefaRecorrenteController/Delete/5
        public ActionResult Delete(int id)
        {
            Tarefarecorrente tarefarecorrente = _tarefarecorrenteService.Buscar(id);
            TarefaRecorrenteModel tarefaRecorrenteModel = _mapper.Map<TarefaRecorrenteModel>(tarefarecorrente);
            return View(tarefaRecorrenteModel);
        }

        // POST: TarefaRecorrenteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TarefaRecorrenteModel tarefaRecorrenteModel)
        {
            _tarefarecorrenteService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
