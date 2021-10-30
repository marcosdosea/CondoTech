using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
    public class TarefaRecorrenteController : Controller
    {
        // GET: TarefaRecorrenteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TarefaRecorrenteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarefaRecorrenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefaRecorrenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
