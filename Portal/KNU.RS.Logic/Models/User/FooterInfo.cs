using System;

namespace KNU.RS.Logic.Models.User
{
    public class FooterInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPhoto { get; set; }
    }
}
