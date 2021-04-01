using KNU.RS.PlatformExtensions.Enums;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace KNU.RS.PlatformExtensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration, ConnectionString connectionStringType)
        {
            var attribute = typeof(ConnectionString)
                .GetMember(connectionStringType.ToString())
                .Single()
                .GetCustomAttribute<DescriptionAttribute>();

            var configKey = attribute?.Description ?? connectionStringType.ToString();

            return configuration.GetConnectionString(configKey);
        }
    }
}
