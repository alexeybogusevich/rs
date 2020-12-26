using System;
using System.Text.Json.Serialization;

namespace KNU.RS.DbManager.Models
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
    }
}
