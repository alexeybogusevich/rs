using AutoMapper;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Mapper;
using KNU.RS.Logic.Middleware;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.EmailingService;
using KNU.RS.Logic.Services.PasswordService;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.PlatformExtensions.Configuration;
using KNU.RS.PlatformExtensions.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KNU.RS.API
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
            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionString.Database)));

            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            services.AddSingleton<IMapper>(service => new Mapper(mapperConfig));

            services.AddScoped<IAccountService, BaseAccountService>();
            services.AddScoped<IEmailingService, BaseEmailingService>();
            services.AddScoped<IPasswordService, BasePasswordService>();
            services.AddScoped<IPatientService, BasePatientService>();

            services.Configure<EmailingConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Emailing).Bind(options));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KNU.RS.API", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KNU.RS.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGlobalExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
