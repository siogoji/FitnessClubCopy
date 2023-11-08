using System.ComponentModel.DataAnnotations;

namespace FitnessClubCopy.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле Ім'я є обов'язковим для заповнення.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Пошта є обов'язковим для заповнення.")]
        [EmailAddress(ErrorMessage = "Невірний формат пошти")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Нікнейм є обов'язковим для заповнення.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле Пароль є обов'язковим для заповнення.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Мінімальна довжина 6 і повинна містити 1 велику літеру, 1 малу літеру, 1 спеціальний символ і 1 цифру")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле Підтвердження паролю є обов'язковим для заповнення.")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string PasswordConfirm { get; set; }
        public string? Role { get; set; }
    }
}
