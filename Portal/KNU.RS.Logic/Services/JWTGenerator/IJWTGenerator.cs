using KNU.RS.Data.Models;
using System.Collections.Generic;

namespace KNU.RS.Logic.Services.JWTGenerator
{
    public interface IJWTGenerator
    {
        string CreateToken(User user, IEnumerable<string> roles);
    }
}