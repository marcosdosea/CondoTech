using AutoMapper;
using CondoTechWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Controllers
{
    [Authorize]
    public class OcorrenciaController : Controller
    {
        IOcorrenciaService _ocorrenciaService;
        IMapper _mapper;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, IMapper mapper)
        {
            _ocorrenciaService = ocorrenciaService;
            _mapper = mapper;
        }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OcorrenciaModel ocorrenciaModel)
        {
            _ocorrenciaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
