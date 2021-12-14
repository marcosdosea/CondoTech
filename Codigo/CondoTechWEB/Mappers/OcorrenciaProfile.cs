using AutoMapper;
using Core;
using CondoTechWEB.Models;

namespace CondoTechWEB.Mappers
{
    public class OcorrenciaProfile : Profile
    {
        public OcorrenciaProfile()
        {
            CreateMap<OcorrenciaModel, Ocorrencias>().ReverseMap();
        }
    }
}
