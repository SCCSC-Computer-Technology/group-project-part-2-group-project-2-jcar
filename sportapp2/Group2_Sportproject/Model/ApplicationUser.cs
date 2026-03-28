using Microsoft.AspNetCore.Identity;

namespace Group2_Sportproject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}