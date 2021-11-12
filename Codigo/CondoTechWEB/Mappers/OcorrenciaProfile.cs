using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
