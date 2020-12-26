using System;
using System.Collections.Generic;
using System.Text;

namespace KNU.RS.DbManager.Models
{
    public class Study
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public decimal Price { get; set; }
    }
}
