using Microsoft.AspNetCore.Identity;

namespace SUPClub.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirsName {  get; set; }
        public string? LastName { get; set; }
    }
}
