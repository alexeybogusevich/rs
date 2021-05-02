using KNU.RS.Data.Models;
using System.Linq;

namespace KNU.RS.Logic.Helpers
{
    public static class NameHelper
    {
        public static string GetFullName(User user)
        {
            return $"{user.LastName} {user.FirstName} {user.MiddleName}";
        }

        public static string GetShortName(User user)
        {
            return $"{user.LastName} {user.FirstName?.FirstOrDefault()}. {user.MiddleName?.FirstOrDefault()}.";
        }
    }
}
