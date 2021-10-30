using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class OcorrenciaService : IOcorrenciaService
    {
        private readonly CondoTechContext _context;

        public OcorrenciaService(CondoTechContext context)
        {
            _context = context;
        }

        public void Alterar(Ocorrencias ocorrencia)
        {
            _context.Update(ocorrencia);
            _context.SaveChanges();
        }

        public Ocorrencias Buscar(int IdOcorrencias)
        {
            var _ocorrencia = _context.Ocorrencias.Find(IdOcorrencias);
            return _ocorrencia;
        }

        public int Inserir(Ocorrencias ocorrencia)
        {
            _context.Add(ocorrencia);
            _context.SaveChanges();
            return ocorrencia.IdOcorrencias;
        }

        public void Remover(int IdOcorrencias)
        {
            var _ocorrencia = _context.Ocorrencias.Find(IdOcorrencias);
            _context.Ocorrencias.Remove(_ocorrencia);
            _context.SaveChanges();
        }

        public void Validar(Ocorrencias ocorrencia)
        {
            throw new NotImplementedException();
        }
    }
}
