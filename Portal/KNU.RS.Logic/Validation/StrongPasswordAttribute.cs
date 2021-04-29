using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = (string)value;
            return password.Any(c => char.IsUpper(c)) && password.Any(c => char.IsDigit(c)) && password.Length > 5 && password.All(c => !char.IsWhiteSpace(c));
        }
    }
}
