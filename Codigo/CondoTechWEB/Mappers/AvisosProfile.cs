using AutoMapper;
using Core;
using CondoTechWEB.Models;

namespace Mappers
{
    public class AvisoProfile : Profile
    {
        public AvisoProfile() {
            CreateMap<AvisoModel, Aviso>().ReverseMap();
        }
    }
}
