using System.ComponentModel.DataAnnotations;

namespace HealthBookTracker.WebUI.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}