using System;

namespace KNU.RS.DbManager.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
