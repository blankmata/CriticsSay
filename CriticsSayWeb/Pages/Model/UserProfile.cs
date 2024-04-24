using System.ComponentModel.DataAnnotations;

namespace CriticsSayWeb.Pages.Model
{
    public class UserProfile
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
