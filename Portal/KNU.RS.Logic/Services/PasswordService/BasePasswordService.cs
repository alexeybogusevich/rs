using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNU.RS.Logic.Services.PasswordService
{
    public class BasePasswordService : IPasswordService
    {
        private static readonly string LowerCase = "abcdefghijkmnopqrstuvwxyz";
        private static readonly string UpperCase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        private static readonly string Digits = "0123456789";
        private static readonly string NonAlphaNumeric = "!@$?_-";

        public string GeneratePassword(PasswordOptions options)
        {
            var randomChars = new List<string>
            {
                LowerCase
            };

            var rand = new Random(Environment.TickCount);

            var chars = new List<char>()
            {
                LowerCase[rand.Next(0, LowerCase.Length)]
            };

            if (options.RequireUppercase)
            {
                randomChars.Add(UpperCase);
                chars.Insert(rand.Next(0, chars.Count), UpperCase[rand.Next(0, UpperCase.Length)]);
            }

            if (options.RequireDigit)
            {
                randomChars.Add(Digits);
                chars.Insert(rand.Next(0, chars.Count), Digits[rand.Next(0, Digits.Length)]);
            }

            if (options.RequireNonAlphanumeric)
            {
                randomChars.Add(NonAlphaNumeric);
                chars.Insert(rand.Next(0, chars.Count), NonAlphaNumeric[rand.Next(0, NonAlphaNumeric.Length)]);
            }

            if (chars.Count < options.RequiredLength)
            {
                for (int i = chars.Count; i < options.RequiredLength; i++)
                {
                    var builder = new StringBuilder();

                    randomChars.ForEach(c =>
                    {
                        builder.Append(c);
                    });

                    var randoms = builder.ToString();

                    chars.Insert(rand.Next(0, randomChars.Count()), randoms[rand.Next(0, randoms.Count())]);
                }
            }

            return new string(chars.ToArray());
        }
    }
}
