using DAL.Enum;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Position Position { get; set; }

        public int? Age { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}