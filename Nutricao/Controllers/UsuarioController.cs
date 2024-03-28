using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Interfaces;
using Nutricao.Models;

namespace Nutricao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            try
            {
                var user = await _usuarioService.BuscarUsuario(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var user = await _usuarioService.CriarUsuario(usuario);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                var user = await _usuarioService.DeletarUsuario(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var user = await _usuarioService.AtualizarUsuario(usuario);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
