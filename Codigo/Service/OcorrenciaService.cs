using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly CondoTechContext _context;

        public OcorrenciaService(CondoTechContext context)
        {
            _context = context;
        }

        public void Update(Ocorrencias ocorrencia)
        {
            _context.Update(ocorrencia);
            _context.SaveChanges();
        }

        public Ocorrencias Get(int IdOcorrencias)
        {
            var _ocorrencia = _context.Ocorrencias.Find(IdOcorrencias);
            return _ocorrencia;
        }

        public int Insert(Ocorrencias ocorrencia)
        {
            _context.Add(ocorrencia);
            _context.SaveChanges();
            return ocorrencia.IdOcorrencia;
        }

        public void Delete(int IdOcorrencias)
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
