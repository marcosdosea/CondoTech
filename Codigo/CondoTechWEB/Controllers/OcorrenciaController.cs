using AutoMapper;
using CondoTechWEB.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [HttpPost]
        [ValidateAntiForgeryToken]

        public OcorrenciaResult Create(OcorrenciaModel ocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencias>(OcorrenciaModel);
                _ocorrenciaService.Inserir(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public OcorrenciaResult Delete(int id, OcorrenciaModel ocorrenciaModel)
        {
            _ocorrenciaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
