using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Core.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Nome de usuário necessário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Senha necessária")]
        public string Password { get; set; }
    }
}
