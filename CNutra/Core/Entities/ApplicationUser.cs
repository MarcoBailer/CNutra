using Microsoft.AspNetCore.Identity;

namespace JwtAuth.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
