using System;

namespace KNU.RS.DbManager.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
