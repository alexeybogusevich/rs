using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KNU.RS.Portal.Constants;
using KNU.RS.Data.Connections;
using KNU.RS.Data.Models;
using SendGrid;
using KNU.RS.Portal.Services.EmailSender;
using Microsoft.AspNetCore.Identity.UI.Services;
using KNU.RS.Portal.Configuration;

namespace KNU.RS.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AzureSqlDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetSection(ConfigurationConstants.Database)[ConfigurationConstants.ConnectionString]));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AzureSqlDbContext>();

            var apiKey = Configuration.GetSection(ConfigurationConstants.Emailing)[ConfigurationConstants.ApiKey];
            
            services.AddScoped<ISendGridClient>(service => new SendGridClient(apiKey));
            services.AddScoped<IEmailSender, EmailSender>();

            services.Configure<EmailingConfiguration>
                (options => Configuration.GetSection(ConfigurationConstants.Emailing).Bind(options));

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
