using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [CompareAttribute("Email", ErrorMessage = "Email and confirm email fields must match")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [CompareAttribute("Password", ErrorMessage = "Password and confirm password fields must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}