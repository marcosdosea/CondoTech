using AutoMapper;
using CondoTechWEB.Models;
using Core;

namespace CondoTechWEB.Mappers
{
    public class DisponibilidadeareaProfile : Profile
    {
        public DisponibilidadeareaProfile()
        {
            CreateMap<DisponibilidadeareaModel, Disponibilidadearea>().ReverseMap();
        }
    }
}
