using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidBirthdayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var givenBirthday = (DateTime)value;
            var lowerLimit = new DateTime(1900, 01, 01);
            var upperLimit = DateTime.Now;
            return lowerLimit < givenBirthday && givenBirthday < upperLimit;
        }
    }
}
