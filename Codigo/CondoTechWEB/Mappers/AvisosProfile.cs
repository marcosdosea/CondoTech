using AutoMapper;
using Core;
using CondoTechWEB.Models;

namespace Mappers
{
    public class AvisosProfile : Profile
    {
        public AvisosProfile() {
            CreateMap<AvisosModel, Avisos>().ReverseMap();
        }
    }
}
