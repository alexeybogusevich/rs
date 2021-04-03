using KNU.RS.Data.Models;

namespace KNU.RS.Logic.Services.JWTGenerator
{
    public interface IJWTGenerator
    {
        string CreateToken(User user);
    }
}