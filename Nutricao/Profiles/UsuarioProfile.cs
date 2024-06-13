using AutoMapper;
using Nutricao.Core.Dtos.Usuario;
using Nutricao.Models;

namespace Nutricao.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, User>();
        }
    }
}
