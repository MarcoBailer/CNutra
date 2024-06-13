using Microsoft.AspNetCore.Mvc;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IUsuario
    {
        //Metodos para criar, atualizar, deletar e buscar usuarios
        Task<User> CriarUsuario([FromBody] User usuario);
        Task<User> AtualizarUsuario(User usuario);
        Task<User> DeletarUsuario(int id);
        Task<User> BuscarUsuario(int id);
    }
}
