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

                patient.Weight = model.Weight;
                patient.Height = model.Height;
                patient.MaritalStatus = model.MaritalStatus;
                patient.EducationStatus = model.EducationStatus;
                patient.Occupation = model.Occupation;
                patient.Job = model.Job;
                patient.Position = model.Position;
                patient.HealthInsuranse = model.HealthInsuranse;
                patient.HealthInsuranseCompany = model.HealthInsuranseCompany;
                patient.Passport = model.Passport;
                patient.Complaints = model.Complaints;
                patient.Diagnosis = model.Diagnosis;
                patient.RegistrationDate = DateTime.Now;

                var result = await userManager.UpdateAsync(user);
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            if (model.Photo != null)
            {
                user.HasPhoto = true;
                await SetPhotoAsync(user, model.Photo);
            }

            await context.SaveChangesAsync();
            await emailingService.SendEmailAsync(user, EmailType.Registration, password);
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

                await userManager.CreateAsync(user);
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

                var result = await userManager.UpdateAsync(user);
            }

            if (doctor == null)
            {
                doctor = mapper.Map<Doctor>(model);
                doctor.UserId = user.Id;

                await userManager.AddToRoleAsync(user, RoleName.Doctor);
                await context.Doctors.AddAsync(doctor);
            }
            else
            {
                doctor.QualificationId = model.QualificationId;
                doctor.ClinicId = model.ClinicId;
                doctor.Biography = model.Biography;
                doctor.Competencies = model.Competencies;
                doctor.Degree = model.Degree;
                doctor.Room = model.Room;
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            if (model.Photo != null)
            {
                user.HasPhoto = true;
                await SetPhotoAsync(user, model.Photo);
            }

            await context.SaveChangesAsync();
            await emailingService.SendEmailAsync(user, EmailType.Registration, password);
        }

        public async Task EditAsync(PatientRegistrationModel model)
        {
            var user = await context.Users
                .Include(u => u.Patient)
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            var patient = user?.Patient;

            if (user == null)
            {
                throw new ArgumentException($"Користувача не знайдено. Email: {model.Email}");
            }
            else if (patient == null)
            {
                throw new ArgumentException($"Користувач не є пацієнтом. Email: {model.Email}");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Gender = model.Gender;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.Birthday = model.Birthday;

                patient.Weight = model.Weight;
                patient.Height = model.Height;
                patient.MaritalStatus = model.MaritalStatus;
                patient.EducationStatus = model.EducationStatus;
                patient.Occupation = model.Occupation;
                patient.Job = model.Job;
                patient.Position = model.Position;
                patient.HealthInsuranse = model.HealthInsuranse;
                patient.HealthInsuranseCompany = model.HealthInsuranseCompany;
                patient.Passport = model.Passport;
                patient.Complaints = model.Complaints;
                patient.Diagnosis = model.Diagnosis;

                var result = await userManager.UpdateAsync(user);
            }

            if (model.Photo != null)
            {
                user.HasPhoto = true;
                await SetPhotoAsync(user, model.Photo);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditAsync(DoctorRegistrationModel model)
        {
            var user = await context.Users
                .Include(u => u.Doctor)
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            var doctor = user?.Doctor;

            if (user == null)
            {
                throw new ArgumentException($"Користувача не знайдено. Email: {model.Email}");
            }
            else if (doctor == null)
            {
                throw new ArgumentException($"Користувач не є лікарем. Email: {model.Email}");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Gender = model.Gender;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.Birthday = model.Birthday;

                doctor.QualificationId = model.QualificationId;
                doctor.ClinicId = model.ClinicId;
                doctor.Biography = model.Biography;
                doctor.Competencies = model.Competencies;
                doctor.Degree = model.Degree;
                doctor.Room = model.Room;

                var result = await userManager.UpdateAsync(user);
            }

            if (model.Photo != null)
            {
                user.HasPhoto = true;
                await SetPhotoAsync(user, model.Photo);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditAsync(RegistrationModel model)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email.Equals(model.Email));

            if (user == null)
            {
                throw new ArgumentException($"Користувача не знайдено. Email: {model.Email}");
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Gender = model.Gender;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.Birthday = model.Birthday;

                var result = await userManager.UpdateAsync(user);
            }

            if (model.Photo != null)
            {
                user.HasPhoto = true;
                await SetPhotoAsync(user, model.Photo);
            }

            await context.SaveChangesAsync();
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

        public async Task PromoteToAdminAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException($"Користувача не знайдено. Id: {id}");
            }

            await userManager.AddToRoleAsync(user, RoleName.Admin);
            await userManager.UpdateAsync(user);

            user.PromotedToAdmin = true;
            context.Users.Update(user);
            await context.SaveChangesAsync();
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

        private async Task SetPhotoAsync(User user, byte[] photo)
        {
            try
            {
                await photoService.UploadAsync(user.Id, photo);
            }
            catch (Exception)
            {
                user.HasPhoto = false;
            }
        }
    }
}
