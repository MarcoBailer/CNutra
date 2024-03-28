using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Interfaces;
using Nutricao.Models;

namespace Nutricao.Core.Service
{
    public class UsuarioService : IUsuario
    {
        private readonly RefeicaoContext _context;

        public UsuarioService(RefeicaoContext context)
        {
            _context = context;
        }
        public async Task<Usuario> BuscarUsuario(int id)
        {
            try
            {
                var user = await _context.Usuarios.FindAsync(id);
                if (user == null)
                {
                    throw new Exception("Usuario não encontrado");
                }
                return user;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Usuario> CriarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Usuario> DeletarUsuario(int id)
        {
            try
            {
                var user = await _context.Usuarios.FindAsync(id);
                if(user == null)
                {
                    throw new Exception("Usuario não encontrado");
                }
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Usuario> AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
