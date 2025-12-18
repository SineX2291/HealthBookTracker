using System.ComponentModel.DataAnnotations;

namespace HealthBookTracker.WebUI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}
