using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trlifaj.Choirify.Models;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using Trlifaj.Choirify.Models.ManyToMany;

namespace Trlifaj.Choirify.Data
{
    public class ChoirDbContext : IdentityDbContext<ApplicationUser>
    {
        //public static readonly LoggerFactory MyConsoleLoggerFactory = new LoggerFactory
        //    (new[] {
        //        new ConsoleLoggerProvider((category, level) =>
        //        category == DbLoggerCategory.Database.Command.Name
        //        && level == LogLevel.Information, true) });

        
        public DbSet<Event> Events { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Rehearsal> Rehearsals { get; set; }
        public DbSet<Song> Songs { get; set; }

        public DbSet<EventAttendance> EventAttendances { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<EventSong> EventSongs { get; set; }
        public DbSet<RehearsalAttendance> RehearsalAttendances { get; set; }
        public DbSet<RehearsalSong> RehearsalSongs { get; set; }
        public DbSet<UserSong> Sheets { get; set; }

        public ChoirDbContext(DbContextOptions<ChoirDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseLoggerFactory(MyConsoleLoggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
        public DbSet<Trlifaj.Choirify.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
