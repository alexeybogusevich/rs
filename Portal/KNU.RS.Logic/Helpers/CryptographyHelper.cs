using System;
using System.Security.Cryptography;

namespace KNU.RS.Logic.Helpers
{
    public static class CryptographyHelper
    {
        public static string GetRandomMD5Hash()
        {
            var bytes = new byte[16];
            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
