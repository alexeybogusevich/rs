using Microsoft.AspNetCore.Identity;
using System;

namespace KNU.RS.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Address { get; set; }
    }
}
