using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NowAndOnDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var givenDate = (DateTime)value;
            return givenDate >= DateTime.Today;
        }
    }
}
