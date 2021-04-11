using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Будь-ласка, введіть email адресу")]
        [EmailAddress(ErrorMessage = "Будь-ласка, введіть валідну email адресу")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
