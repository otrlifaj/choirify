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

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SingerSong>()
                .HasIndex(ss => ss.SingerId);
            builder.Entity<SingerSong>()
                .HasIndex(ss => ss.SongId);
            builder.Entity<SingerSong>()
                .HasIndex(ss => ss.Status);

            // soft delete on domain entities
            builder.Entity<Event>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Link>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<News>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Rehearsal>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Singer>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Song>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ApplicationUser>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Choirmaster>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
