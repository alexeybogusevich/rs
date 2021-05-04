using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.User;
using System;
using System.Collections.Generic;

namespace KNU.RS.Logic.Models.Doctor
{
    public class DoctorInfo : UserInfo
    {
        public Guid Id { get; set; }
        public Guid? QualificationId { get; set; }
        public string QualificationName { get; set; }
        public Guid? ClinicId { get; set; }
        public int Room { get; set; }
        public string Biography { get; set; }
        public string Competencies { get; set; }
        public string Degree { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicPhoneNumber { get; set; }
        public string ClinicWorkingHours { get; set; }
        public bool PromotedToAdmin { get; set; }
        public IEnumerable<Education> Educations { get; set; }
    }
}
