using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.User;

namespace KNU.RS.Logic.Converters
{
    public static class UserConverter
    {
        public static FooterInfo Convert(User user)
        {
            return new FooterInfo
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
