using AutoMapper;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class RefeicaoMVN : Profile
    {
        public RefeicaoMVN()
        {
            CreateMap<CreateRefeicaoDto, RefeicaoMVN>();
            CreateMap<ReadRefeicaoDto, RefeicaoMVN>();
            CreateMap<UpdateRefeicaoDto, RefeicaoMVN>();
        }
    }
}
