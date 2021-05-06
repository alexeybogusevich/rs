using AutoMapper;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Mapper;
using KNU.RS.Logic.Middleware;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.Logic.Services.DoctorService;
using KNU.RS.Logic.Services.EmailingService;
using KNU.RS.Logic.Services.LoginService;
using KNU.RS.Logic.Services.PasswordService;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.Logic.Services.QualificationService;
using KNU.RS.Logic.Services.RecoveryPlanService;
using KNU.RS.Logic.Services.ReportService;
using KNU.RS.Logic.Services.StudyService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.PlatformExtensions.Configuration;
using KNU.RS.PlatformExtensions.Enums;
using KNU.RS.UI.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace KNU.RS.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionString.Database)));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            services.AddSingleton<IMapper>(service => new Mapper(mapperConfig));

            services.AddScoped<IAccountService, BaseAccountService>();
            services.AddScoped<IClinicService, BaseClinicService>();
            services.AddScoped<IDoctorService, BaseDoctorService>();
            services.AddScoped<IEmailingService, BaseEmailingService>();
            services.AddScoped<ILoginService, BaseLoginService>();
            services.AddScoped<IPasswordService, BasePasswordService>();
            services.AddScoped<IPatientService, BasePatientService>();
            services.AddScoped<IPhotoService, BasePhotoService>();
            services.AddScoped<IRecoveryPlanService, BaseRecoveryPlanService>();
            services.AddScoped<IReportService, BaseReportService>();
            services.AddScoped<IStudyService, BaseStudyService>();
            services.AddScoped<IUserService, BaseUserService>();
            services.AddScoped<IQualificationService, BaseQualificationService>();

            services.AddHttpContextAccessor();

            services.Configure<EmailingConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Emailing).Bind(options));
            services.Configure<PhotoConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Photo).Bind(options));
            services.Configure<ReportConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Report).Bind(options));

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddSignalR().AddAzureSignalR(options =>
            {
                options.ServerStickyMode = Microsoft.Azure.SignalR.ServerStickyMode.Required;
                options.ConnectionString = Configuration.GetConnectionString(ConnectionString.SignalR);
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IHostEnvironmentAuthenticationStateProvider>(sp =>
                (ServerAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>()
            );

            services.AddAuthentication();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/signin";
                options.LogoutPath = "/signin";
                options.AccessDeniedPath = "/signin";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGlobalExceptionHandler();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
