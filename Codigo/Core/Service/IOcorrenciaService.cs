using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOcorrenciaService
    {
        int Insert(Ocorrencias ocorrencia);

        void Validar(Ocorrencias ocorrencia);

        void Update(Ocorrencias ocorrencia);

        Ocorrencias Get(int IdOcorrencias);

        void Delete(int IdOcorrencias);
    }
}
