using AutoMapper;
using CondoTechWEB.Models;
using Core;

namespace CondoTechWEB.Mappers
{
    public class AreacomumProfile : Profile
    {
        public AreacomumProfile()
        {
            CreateMap<AreacomumModel, Areacomum>().ReverseMap();
        }
    }
}
