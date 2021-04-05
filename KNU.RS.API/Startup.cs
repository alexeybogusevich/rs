using AutoMapper;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Mapper;
using KNU.RS.Logic.Middleware;
using KNU.RS.Logic.Services.AuthenticationService;
using KNU.RS.Logic.Services.EmailingService;
using KNU.RS.Logic.Services.JWTGenerator;
using KNU.RS.Logic.Services.PasswordService;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.RegistrationService;
using KNU.RS.PlatformExtensions.Configuration;
using KNU.RS.PlatformExtensions.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

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

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            services.AddSingleton<IMapper>(service => new Mapper(mapperConfig));

            services.AddScoped<IAuthenticationService, JWTAuthenticationService>();
            services.AddScoped<IEmailingService, BaseEmailingService>();
            services.AddScoped<IJWTGenerator, HMACSHA512JWTGenerator>();
            services.AddScoped<IPasswordService, BasePasswordService>();
            services.AddScoped<IRegistrationService, BaseRegistrationService>();
            services.AddScoped<IPatientService, BasePatientService>();

            services.Configure<EmailingConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Emailing).Bind(options));

            services.Configure<TokenConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Token).Bind(options));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Token:Key"]));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .Build();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KNU.RS.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                    Enter 'Bearer' [space] and then your token in the text input below. Example : 'Bearer 12345'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
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
