using AutoMapper;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos.Refeicao_MVN;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class RefeicaoMVNProfile : Profile
    {
        public RefeicaoMVNProfile()
        {
            CreateMap<CreateRefeicaoDto, RefeicaoMVN>();
            CreateMap<RefeicaoMVN, ReadRefeicaoDto>();
            CreateMap<CalculoDaRefeicao, ReadCalculoDto>();
            CreateMap<UpdateRefeicaoDto, RefeicaoMVN>();
        }
    }
}
