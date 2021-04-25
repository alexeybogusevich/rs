using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PositiveIntAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (int)value > 0;
        }
    }
}
