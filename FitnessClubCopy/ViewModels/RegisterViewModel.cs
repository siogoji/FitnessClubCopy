using System.ComponentModel.DataAnnotations;

namespace FitnessClubCopy.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Мінімальна довжина 6 і повинна містити 1 велику літеру, 1 малу літеру, 1 спеціальний символ і 1 цифру")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string? Role { get; set; }
    }
}
