using AutoMapper;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Clinic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.ClinicService
{
    public class BaseClinicService : IClinicService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public BaseClinicService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Clinic>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await context.Clinics.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ClinicModel>> GetModelAsync(CancellationToken cancellationToken = default)
        {
            return await context.Clinics
                .Select(c => ClinicConverter.Convert(c))
                .ToListAsync(cancellationToken);
        }

        public async Task<ClinicModel> GetModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var clinic = await context.Clinics.FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
            return mapper.Map<ClinicModel>(clinic);
        }

        public async Task CreateAsync(ClinicModel model)
        {
            var clinic = mapper.Map<Clinic>(model);
            await context.Clinics.AddAsync(clinic);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClinicModel model)
        {
            var clinic = await context.Clinics.FindAsync(model.Id);
            if (clinic == null)
            {
                return;
            }

            clinic.Name = model.Name;
            clinic.Location = model.Location;
            clinic.PhoneNumber = model.PhoneNumber;
            clinic.WorkingHours = model.WorkingHours;

            context.Clinics.Update(clinic);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var clinic = await context.Clinics.FindAsync(id);
            context.Clinics.Remove(clinic);
            await context.SaveChangesAsync();
        }
    }
}
