using AutoMapper;
using KNU.RS.Data.Constants;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Enums;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.EmailingService;
using KNU.RS.Logic.Services.PasswordService;
using KNU.RS.Logic.Services.PhotoService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public class BaseAccountService : IAccountService
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;

        private readonly IMapper mapper;

        private readonly IEmailingService emailingService;
        private readonly IPasswordService passwordService;
        private readonly IPhotoService photoService;

        public BaseAccountService(ApplicationContext context, IMapper mapper,
            UserManager<User> userManager,
            IEmailingService emailingService, IPasswordService passwordService,
            IPhotoService photoService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.emailingService = emailingService;
            this.passwordService = passwordService;
            this.photoService = photoService;
        }

        public async Task RegisterAsync(PatientRegistrationModel model)
        {
            var user = await context.Users
                .Include(u => u.Patient)
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            var patient = user?.Patient;

            if (user == null)
            {
                user = mapper.Map<User>(model);
                user.Id = Guid.NewGuid();
                user.UserName = model.Email;

                patient = mapper.Map<Patient>(model);
                patient.UserId = user.Id;

                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, RoleName.Patient);
                await context.Patients.AddAsync(patient);
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Gender = model.Gender;
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Birthday = model.Birthday;

                patient.Description = model.Description;
                patient.Height = model.Height;
                patient.Weight = model.Weight;

                var result = await userManager.UpdateAsync(user);
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            await context.SaveChangesAsync();
            await emailingService.SendEmailAsync(user, EmailType.Registration, password);

            if (model.Photo != null)
            {
                await photoService.UploadAsync(user.Id, model.Photo);
                user.HasPhoto = true;
            }
        }

        public async Task RegisterAsync(DoctorRegistrationModel model)
        {
            var user = await context.Users
                .Include(u => u.Doctor)
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            var doctor = user?.Doctor;

            if (user == null)
            {
                user = mapper.Map<User>(model);
                user.Id = Guid.NewGuid();
                user.UserName = model.Email;

                doctor = mapper.Map<Doctor>(model);
                doctor.UserId = user.Id;

                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, RoleName.Doctor);
                await context.Doctors.AddAsync(doctor);
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Gender = model.Gender;
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                doctor.QualificationId = model.QualificationId;
                doctor.ClinicId = model.ClinicId;
                doctor.Biography = model.Biography;

                var result = await userManager.UpdateAsync(user);
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            await context.SaveChangesAsync();
            await emailingService.SendEmailAsync(user, EmailType.Registration, password);

            if (model.Photo != null)
            {
                await photoService.UploadAsync(user.Id, model.Photo);
                user.HasPhoto = true;
            }
        }

        public async Task HandleForgotPasswordAsync(ForgotPasswordModel model)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            if (user != null)
            {
                var password = passwordService.GeneratePassword(userManager.Options.Password);
                await SetPasswordAsync(user, password);

                await context.SaveChangesAsync();
                await emailingService.SendEmailAsync(user, EmailType.ForgotPassword, password);
            }
        }

        private async Task SetPasswordAsync(User user, string password)
        {
            IdentityResult setPasswordResult;

            if (await userManager.HasPasswordAsync(user))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                setPasswordResult = await userManager.ResetPasswordAsync(user, token, password);
            }
            else
            {
                setPasswordResult = await userManager.AddPasswordAsync(user, password);
            }

            if (!setPasswordResult.Succeeded)
            {
                var errors = new StringBuilder();
                setPasswordResult.Errors.ToList().ForEach(error => errors.AppendLine(error.Description));
                throw new InvalidOperationException(errors.ToString());
            }

            context.Entry(user).State = EntityState.Modified;
        }
    }
}
