using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.User;
using System.IO;

namespace KNU.RS.Logic.Helpers
{
    public static class PhotoHelper
    {
        public static string GetURI(UserInfo user, PhotoConfiguration configuration)
        {
            if (user.HasPhoto)
            {
                return Path.Combine(configuration.Directory, $"{user.UserId}.{configuration.Extension}");
            }

            return "img/user.jpg";
        }
    }
}
