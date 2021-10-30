using AutoMapper;
using CondoTechWEB.Models;
using Core;

namespace CondoTechWEB.Mappers
{
    public class CondominioProfile : Profile
    {
        public CondominioProfile()
        {
            CreateMap<CondominioModel, Condominio>().ReverseMap();
        }
    }
}
