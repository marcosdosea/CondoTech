using AutoMapper;
using CondoTechWEB.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
