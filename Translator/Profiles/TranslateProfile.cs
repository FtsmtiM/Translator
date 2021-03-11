using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Dtos;
using Translator.Models;

namespace Translator.Profiles
{
    public class TranslateProfile : Profile
    {
        public TranslateProfile()
        {
            CreateMap<Translate, TranslateReadDto>();
            CreateMap<TranslateCreateDto, Translate>();
            CreateMap<TranslateUpdateDto, Translate>();
            CreateMap<Translate, TranslateUpdateDto>();
        }
    }
}
