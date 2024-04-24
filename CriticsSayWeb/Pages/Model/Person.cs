using System.ComponentModel.DataAnnotations;

namespace CriticsSayWeb.Pages.Model
{
    public class Person
    {
        public int? PersonId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name ")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name  = "Last Name ")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "An email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A password is required")]
        [MinLength(10, ErrorMessage = "The password must be at least 10 characters long.")]
        [Display(Name = "Password ")]
        public string? Password { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int RoleId { get; set; }

    }
}
