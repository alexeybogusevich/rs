using System;

namespace KNU.RS.Data.Constants
{
    public class RoleId
    {
        private static Guid adminId = new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3");
        private static Guid doctorId = new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3");
        private static Guid patientId = new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17");

        public static Guid AdminId { get => adminId; }
        public static Guid DoctorId { get => doctorId; }
        public static Guid PatientId { get => patientId; }
    }
}
