using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDisponibilidadeareaService
    {
        int Insert(Disponibilidadearea disponibilidadearea);

        void Update(Disponibilidadearea disponibilidadearea);

        Disponibilidadearea Get(int IdDisponibilidadeArea);

        void Delete(int IdDisponibilidadeArea);

        bool Validar(Disponibilidadearea disponibilidadearea);

        IEnumerable<Disponibilidadearea> GetByDiaSemana(string DiaSemana);
        IEnumerable<Disponibilidadearea> GetAll();
        IQueryable<Disponibilidadearea> GetQuery();
    }
}
