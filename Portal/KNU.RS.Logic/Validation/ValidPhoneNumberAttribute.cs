using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidPhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var phoneNumber = (string)value;
            var regex = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
