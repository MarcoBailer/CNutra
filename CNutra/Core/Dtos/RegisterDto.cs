using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Core.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Primeiro Nome necessário")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Último Nome necessário")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Nome de Usuário necessário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha necessário")]
        public string Password { get; set; }
        public int Phone { get; set; }

    }
}
