using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (Guid)value != Guid.Empty;
        }
    }
}
