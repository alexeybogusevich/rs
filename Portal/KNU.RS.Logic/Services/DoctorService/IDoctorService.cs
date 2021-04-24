﻿using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> GetAsync(Guid userId);
        Task<IEnumerable<DoctorInfo>> GetInfoAsync();
        Task<Doctor> CreateAsync(Doctor doctor);
    }
}