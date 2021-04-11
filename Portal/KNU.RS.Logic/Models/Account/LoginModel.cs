using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Будь-ласка, введіть поштову адресу")]
        [EmailAddress(ErrorMessage = "Будь-ласка, введіть валідну email адресу")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь-ласка, введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
