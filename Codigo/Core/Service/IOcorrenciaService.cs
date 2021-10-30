using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOcorrenciaService
    {
        int Inserir(Ocorrencias ocorrencia);

        void Validar(Ocorrencias ocorrencia);

        void Alterar(Ocorrencias ocorrencia);

        Ocorrencias Buscar(int IdOcorrencias);

        void Remover(int IdOcorrencias);
    }
}
