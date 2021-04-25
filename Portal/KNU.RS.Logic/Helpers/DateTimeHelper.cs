using System;

namespace KNU.RS.Logic.Helpers
{
    public static class DateTimeHelper
    {
        public static int GetAge(DateTime birthday)
        {
            var today = DateTime.Today;
            int age = today.Year - birthday.Year;

            if (birthday > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
