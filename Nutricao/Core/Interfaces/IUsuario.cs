using Microsoft.AspNetCore.Mvc;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IUsuario
    {
        //Metodos para criar, atualizar, deletar e buscar usuarios
        Task<Usuario> CriarUsuario([FromBody] Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task<Usuario> DeletarUsuario(int id);
        Task<Usuario> BuscarUsuario(int id);
    }
}
