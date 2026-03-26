using System.ComponentModel.DataAnnotations;

namespace Group2_Sportproject.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string IdentityUserId { get; set; } = "";

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";
    }
}