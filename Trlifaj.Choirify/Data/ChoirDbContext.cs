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
using Trlifaj.Choirify.Models.Enums;

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
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Choirmaster> Choirmasters { get; set; }

        public DbSet<EventAttendance> EventAttendances { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<EventSong> EventSongs { get; set; }
        public DbSet<RehearsalAttendance> RehearsalAttendances { get; set; }
        public DbSet<RehearsalSong> RehearsalSongs { get; set; }
        public DbSet<SingerSong> Sheets { get; set; }

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

            // soft delete on domain entities
            builder.Entity<Event>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Link>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<News>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Rehearsal>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Singer>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Song>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ApplicationUser>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Choirmaster>().HasQueryFilter(p => !p.IsDeleted);

            // initial data seeding
            builder.Entity<Song>().HasData(new Song{Id = 1, Name = "21 Guns", Author = "Green day", Current = true, SheetsAvailable = 1, SheetType = SheetType.Unified});
            builder.Entity<Event>().HasData(new Event {Id = 1, Description = "Nějaký popis události", From = new DateTime(2018, 9, 28, 18, 00, 00),
                                                        To = new DateTime(2018, 9, 30, 9, 00, 00), Name = "Soustředění xyz", Place = "Konvikt",
                                                        StartOfRegistration = new DateTime(2018, 9, 2, 0,0,0), EndOfRegistration = new DateTime(2018, 9, 20, 0,0,0)});
            builder.Entity<Singer>().HasData(new Singer { Id = 1, FirstName = "Ondřej", Surname = "Trlifaj", Address = "Adresa ondry trlifaje", DateOfBirth = new DateTime(1992, 1, 1),
                                                    Email = "ondra.trli@centrum.cz", IsActive = true, VoiceGroup = VoiceGroup.B2, NumberOfIDCard = "123456", PassportNumber = "654321",
                                                    PhoneNumber = "+420123456789" });
            builder.Entity<Rehearsal>().HasData(new Rehearsal { Id = 1, Date = new DateTime(2018, 9, 7), Description = "První zkouška semestru", IsDeleted = false });
        }
    }
}
