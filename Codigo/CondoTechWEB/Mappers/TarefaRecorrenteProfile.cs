using AutoMapper;
using CondoTechWEB.Models;
using Core;

namespace CondoTechWEB.Mappers
{
    public class TarefaRecorrenteProfile : Profile
    {
        public TarefaRecorrenteProfile()
        {
            CreateMap<TarefaRecorrenteModel, Tarefarecorrente>().ReverseMap();
        }
    }
}
