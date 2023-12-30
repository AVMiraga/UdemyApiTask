using Microsoft.AspNetCore.Identity;

namespace BlogApp.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsReminded { get; set; }
    }
}