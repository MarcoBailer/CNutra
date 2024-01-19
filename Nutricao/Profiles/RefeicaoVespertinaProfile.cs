using AutoMapper;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class RefeicaoVespertinaProfile : Profile
    {
        public RefeicaoVespertinaProfile()
        {
            CreateMap<CreateRefeicaoDto, RefeicaoVespertina>();
            CreateMap<ReadRefeicaoDto, RefeicaoVespertina>();
            CreateMap<UpdateRefeicaoDto, RefeicaoVespertina>();
        }
    }
}
