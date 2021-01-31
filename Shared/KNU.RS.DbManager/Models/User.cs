using System;

namespace KNU.RS.DbManager.Models
{
    public class User : Microsoft.AspNetCore.Identity. IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
    }
}
