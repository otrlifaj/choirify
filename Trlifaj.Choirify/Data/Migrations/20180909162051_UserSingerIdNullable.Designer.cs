﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trlifaj.Choirify.Data;

namespace Trlifaj.Choirify.Data.Migrations
{
    [DbContext(typeof(ChoirDbContext))]
    [Migration("20180909162051_UserSingerIdNullable")]
    partial class UserSingerIdNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("CanLogin");

                    b.Property<int?>("ChoirmasterId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("GdprApproved");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastLogin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("SingerId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ChoirmasterId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("SingerId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("EndOfRegistration");

                    b.Property<DateTime>("From");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Organizer")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("StartOfRegistration");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new { Id = 1, Description = "Nějaký popis události", EndOfRegistration = new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), From = new DateTime(2018, 9, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), IsDeleted = false, Name = "Soustředění xyz", Place = "Konvikt", StartOfRegistration = new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), To = new DateTime(2018, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Choirmaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NumberOfIDCard")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PassportNumber")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Choirmasters");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(1000);

                    b.Property<int?>("EventId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("SongId");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SongId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Attended");

                    b.Property<int?>("EventId");

                    b.Property<int?>("SingerId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SingerId");

                    b.ToTable("EventAttendances");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Answer");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("DressOrder");

                    b.Property<int?>("EventId");

                    b.Property<int?>("SingerId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SingerId");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<int?>("SongId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SongId");

                    b.ToTable("EventSongs");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.RehearsalAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Attended");

                    b.Property<int?>("RehearsalId");

                    b.Property<int?>("SingerId");

                    b.HasKey("Id");

                    b.HasIndex("RehearsalId");

                    b.HasIndex("SingerId");

                    b.ToTable("RehearsalAttendances");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.RehearsalSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RehearsalId");

                    b.Property<int?>("SongId");

                    b.HasKey("Id");

                    b.HasIndex("RehearsalId");

                    b.HasIndex("SongId");

                    b.ToTable("RehearsalSongs");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.SingerSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SingerId");

                    b.Property<int?>("SongId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SingerId");

                    b.HasIndex("SongId");

                    b.ToTable("Sheets");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(100);

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("Current");

                    b.Property<string>("Headline")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Rehearsal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Rehearsals");

                    b.HasData(
                        new { Id = 1, Date = new DateTime(2018, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "První zkouška semestru", IsDeleted = false }
                    );
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Singer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NumberOfIDCard")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PassportNumber")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("VoiceGroup")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Singers");

                    b.HasData(
                        new { Id = 1, Address = "Adresa ondry trlifaje", DateOfBirth = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "ondra.trli@centrum.cz", FirstName = "Ondřej", IsActive = true, IsDeleted = false, NumberOfIDCard = "123456", PassportNumber = "654321", PhoneNumber = "+420123456789", Surname = "Trlifaj", VoiceGroup = "B2" }
                    );
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Current");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<TimeSpan>("Duration");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("SheetType");

                    b.Property<int>("SheetsAvailable");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new { Id = 1, Author = "Green day", Current = true, Duration = new TimeSpan(0, 0, 0, 0, 0), IsDeleted = false, Name = "21 Guns", SheetType = 0, SheetsAvailable = 1 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trlifaj.Choirify.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ApplicationUser", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Choirmaster", "Choirmaster")
                        .WithMany()
                        .HasForeignKey("ChoirmasterId");

                    b.HasOne("Trlifaj.Choirify.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.Link", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Event")
                        .WithMany("Links")
                        .HasForeignKey("EventId");

                    b.HasOne("Trlifaj.Choirify.Models.Song")
                        .WithMany("Links")
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventAttendance", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Trlifaj.Choirify.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventRegistration", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Trlifaj.Choirify.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.EventSong", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Trlifaj.Choirify.Models.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.RehearsalAttendance", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Rehearsal", "Rehearsal")
                        .WithMany()
                        .HasForeignKey("RehearsalId");

                    b.HasOne("Trlifaj.Choirify.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.RehearsalSong", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Rehearsal", "Rehearsal")
                        .WithMany()
                        .HasForeignKey("RehearsalId");

                    b.HasOne("Trlifaj.Choirify.Models.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.ManyToMany.SingerSong", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId");

                    b.HasOne("Trlifaj.Choirify.Models.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("Trlifaj.Choirify.Models.News", b =>
                {
                    b.HasOne("Trlifaj.Choirify.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });
#pragma warning restore 612, 618
        }
    }
}
