using KNU.RS.Data.Enums;
using System;

namespace KNU.RS.Logic.Models.User
{
    public class UserInfo
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string FormattedBirthday { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
