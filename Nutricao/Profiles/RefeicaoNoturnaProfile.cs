using AutoMapper;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class RefeicaoNoturnaProfile : Profile
    {
        public RefeicaoNoturnaProfile()
        {
            CreateMap<CreateRefeicaoDto, RefeicaoNoturna>();
            CreateMap<ReadRefeicaoDto, RefeicaoNoturna>();
            CreateMap<UpdateRefeicaoDto, RefeicaoNoturna>();
        }
    }
}
