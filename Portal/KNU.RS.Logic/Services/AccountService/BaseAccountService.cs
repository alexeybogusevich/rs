using AutoMapper;
using KNU.RS.Data.Constants;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Enums;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.EmailingService;
using KNU.RS.Logic.Services.JWTGenerator;
using KNU.RS.Logic.Services.PasswordService;
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
        private readonly SignInManager<User> signInManager;

        private readonly IMapper mapper;

        private readonly IEmailingService emailingService;
        private readonly IJWTGenerator jwtGenerator;
        private readonly IPasswordService passwordService;

        public BaseAccountService(ApplicationContext context, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager,
            IEmailingService emailingService, IPasswordService passwordService,
            IJWTGenerator jwtGenerator)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailingService = emailingService;
            this.passwordService = passwordService;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<bool> LoginCookieAsync(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password.Trim(), true, true);
            return result.Succeeded;
        }

        public async Task LogoutCookieAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<string> LoginJWTAsync(LoginModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email.Equals(model.Email));
            if (user == null)
            {
                return null;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password.Trim(), true);
            if (!result.Succeeded)
            {
                return null;
            }

            return jwtGenerator.CreateToken(user);
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
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                patient.Birthday = model.BirthDay;
                patient.Height = model.Height;
                patient.Weight = model.Weight;

                var result = await userManager.UpdateAsync(user);
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            await context.SaveChangesAsync();
            // await emailingService.SendEmailAsync(user, EmailType.Registration, password);
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
            }
            else
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MiddleName = model.MiddleName;
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                doctor.QualificationId = model.QualificationId;
                doctor.ClinicId = model.ClinicId;

                var result = await userManager.UpdateAsync(user);
            }

            var password = passwordService.GeneratePassword(userManager.Options.Password);
            await SetPasswordAsync(user, password);

            await context.SaveChangesAsync();
            await emailingService.SendEmailAsync(user, EmailType.Registration, password);
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
