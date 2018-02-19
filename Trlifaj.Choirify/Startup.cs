using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Database.MySQL;

namespace Trlifaj.Choirify
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
            services.AddDbContext<ChoirDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ChoirDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddScoped<IEventMapper, EventMapper>();
            services.AddScoped<IEventRegistrationMapper, EventRegistrationMapper>();
            services.AddScoped<INewsMapper, NewsMapper>();
            services.AddScoped<IRehearsalMapper, RehearsalMapper>();
            services.AddScoped<ISheetsInfoMapper, SheetsInfoMapper>();
            services.AddScoped<ISongMapper, SongMapper>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
