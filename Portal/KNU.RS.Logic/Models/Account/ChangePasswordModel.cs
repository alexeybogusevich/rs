using KNU.RS.Logic.Validation;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Будь-ласка, введіть актуальний пароль.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Будь-ласка, введіть новий пароль.")]
        [StrongPassword(
            ErrorMessage = "Пароль повинен містити не менше ніж 6 символів без пробілів, " +
                "включаючи як мінімум одну малу, одну велику літеру, одну цифру та один не числовий і не буквенний символ.")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Будь-ласка, підтвердіть новий пароль.")]
        public string NewPasswordConfirmed { get; set; }
    }
}
