using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Будь-ласка, введіть поштову адресу")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь-ласка, введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
