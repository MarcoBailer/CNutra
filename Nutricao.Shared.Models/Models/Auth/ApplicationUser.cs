using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nutricao.Domain.Configuration.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [Required]
        public int Codigo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
