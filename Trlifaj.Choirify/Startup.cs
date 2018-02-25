﻿using System;
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
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ChoirDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "User", "Singer", "Choirmaster", "Voice leader", "Dresscode leader", "Admin", "Chairman", "Vice chairman", "Music distributor", "Manager" };
            IdentityResult roleResult;

            // create all roles in DB
            foreach (var roleName in roleNames)
            {
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminInfo = Configuration.GetSection("Admin");
            var admin = new ApplicationUser
            {
                UserName = adminInfo["Email"],
                FirstName = adminInfo["FirstName"],
                Surname = adminInfo["Surname"],
                Email = adminInfo["Email"],
                PhoneNumber = adminInfo["PhoneNumber"],
                NumberOfIDCard = adminInfo["NumberOfIDCard"],
                PassportNumber = null,
                Address = adminInfo["Address"],
                CanLogin = Boolean.Parse(adminInfo["CanLogin"]),
                IsSinger = Boolean.Parse(adminInfo["IsSinger"]),
                IsActive = Boolean.Parse(adminInfo["IsActive"]),
                EmailConfirmed = true,
                CreatedOn = DateTime.Now
            };
            string adminPassword = adminInfo["Password"];
            var user = await UserManager.FindByEmailAsync(admin.Email);

            if (user == null)
            {
                var createAdmin = await UserManager.CreateAsync(admin, adminPassword);
                if (createAdmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
