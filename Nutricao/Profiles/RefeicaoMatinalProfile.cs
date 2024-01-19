using AutoMapper;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class RefeicaoMatinalProfile : Profile
    {
        public RefeicaoMatinalProfile()
        {
            CreateMap<CreateRefeicaoDto, RefeicaoMatinal>();
            CreateMap<ReadRefeicaoDto, RefeicaoMatinal>();
            CreateMap<UpdateRefeicaoDto, RefeicaoMatinal>();
        }
    }
}
