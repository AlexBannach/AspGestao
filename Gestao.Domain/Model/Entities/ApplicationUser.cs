using Microsoft.AspNetCore.Identity;
namespace Gestao.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
        public string? Name { get; set; }
        public DateTime? Birth { get; set; }
    }

}
