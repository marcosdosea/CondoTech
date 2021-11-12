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
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: PessoaController
        public ActionResult Index()
        {
            var listarPessoa = _pessoaService.GetAll();
            var listarPessoaModel = _mapper.Map<List<PessoaModel>>(listarPessoa);

            return View(listarPessoaModel);
        }



        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _pessoaService.Buscar(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: TarefaRecorrenteController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TarefaRecorrenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            _pessoaService.Inserir(pessoa);
            return RedirectToAction(nameof(Index));
        }

        // GET: TarefaRecorrenteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarefaRecorrenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarefaRecorrenteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarefaRecorrenteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
