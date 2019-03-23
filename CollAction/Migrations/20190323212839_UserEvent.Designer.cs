﻿// <auto-generated />
using System;
using CollAction.Data;
using CollAction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CollAction.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190323212839_UserEvent")]
    partial class UserEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CollAction.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .HasMaxLength(250);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("RepresentsNumberParticipants")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CollAction.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Color");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("File")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CollAction.Models.DataProtectionKey", b =>
                {
                    b.Property<string>("FriendlyName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(449);

                    b.Property<string>("KeyDataXml")
                        .IsRequired();

                    b.HasKey("FriendlyName");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("CollAction.Models.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Filepath")
                        .IsRequired();

                    b.Property<int>("Height");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("CollAction.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("LocationId");

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("CollAction.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryId")
                        .HasMaxLength(2);

                    b.Property<int>("Feature");

                    b.Property<int>("FeatureClass");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric(13,10)");

                    b.Property<string>("Level1Id")
                        .HasMaxLength(20);

                    b.Property<string>("Level2Id")
                        .HasMaxLength(80);

                    b.Property<string>("LocationContinentId");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric(13,10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Level1Id");

                    b.HasIndex("Level2Id");

                    b.HasIndex("LocationContinentId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CollAction.Models.LocationAlternateName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlternateName")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<bool>("IsColloquial");

                    b.Property<bool>("IsHistoric");

                    b.Property<bool>("IsPreferredName");

                    b.Property<bool>("IsShortName");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationAlternateNames");
                });

            modelBuilder.Entity("CollAction.Models.LocationContinent", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationContinents");
                });

            modelBuilder.Entity("CollAction.Models.LocationCountry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2);

                    b.Property<string>("CapitalCity")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ContinentId")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationCountries");
                });

            modelBuilder.Entity("CollAction.Models.LocationLevel1", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationLevel1");
                });

            modelBuilder.Entity("CollAction.Models.LocationLevel2", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationLevel2");
                });

            modelBuilder.Entity("CollAction.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnonymousUserParticipants");

                    b.Property<int?>("BannerImageFileId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("CreatorComments")
                        .HasMaxLength(20000);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<int?>("DescriptionVideoLinkId");

                    b.Property<int?>("DescriptiveImageFileId");

                    b.Property<int>("DisplayPriority")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<DateTime>("End");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumberProjectEmailsSend");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Proposal")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("Start");

                    b.Property<int>("Status");

                    b.Property<int>("Target");

                    b.HasKey("Id");

                    b.HasIndex("BannerImageFileId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DescriptionVideoLinkId");

                    b.HasIndex("DescriptiveImageFileId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Projects_Name");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CollAction.Models.ProjectParticipant", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("ProjectId");

                    b.Property<bool>("SubscribedToProjectEmails");

                    b.Property<Guid>("UnsubscribeToken");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectParticipants");
                });

            modelBuilder.Entity("CollAction.Models.ProjectParticipantCount", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("Count");

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectParticipantCounts");
                });

            modelBuilder.Entity("CollAction.Models.ProjectTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("ProjectId");

                    b.HasKey("TagId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("CollAction.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CollAction.Models.UserEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventData")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("CollAction.Models.VideoLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(2083);

                    b.HasKey("Id");

                    b.ToTable("VideoLinks");
                });

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

            modelBuilder.Entity("CollAction.Models.Job", b =>
                {
                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("CollAction.Models.Location", b =>
                {
                    b.HasOne("CollAction.Models.LocationCountry", "Country")
                        .WithMany("Locations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CollAction.Models.LocationLevel1", "Level1")
                        .WithMany("Locations")
                        .HasForeignKey("Level1Id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CollAction.Models.LocationLevel2", "Level2")
                        .WithMany("Locations")
                        .HasForeignKey("Level2Id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CollAction.Models.LocationContinent")
                        .WithMany("Locations")
                        .HasForeignKey("LocationContinentId");
                });

            modelBuilder.Entity("CollAction.Models.LocationAlternateName", b =>
                {
                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany("AlternateNames")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.LocationContinent", b =>
                {
                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.LocationCountry", b =>
                {
                    b.HasOne("CollAction.Models.LocationContinent", "Continent")
                        .WithMany()
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.LocationLevel1", b =>
                {
                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.LocationLevel2", b =>
                {
                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.Project", b =>
                {
                    b.HasOne("CollAction.Models.ImageFile", "BannerImage")
                        .WithMany()
                        .HasForeignKey("BannerImageFileId");

                    b.HasOne("CollAction.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CollAction.Models.VideoLink", "DescriptionVideoLink")
                        .WithMany()
                        .HasForeignKey("DescriptionVideoLinkId");

                    b.HasOne("CollAction.Models.ImageFile", "DescriptiveImage")
                        .WithMany()
                        .HasForeignKey("DescriptiveImageFileId");

                    b.HasOne("CollAction.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("CollAction.Models.ApplicationUser", "Owner")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("CollAction.Models.ProjectParticipant", b =>
                {
                    b.HasOne("CollAction.Models.Project", "Project")
                        .WithMany("Participants")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CollAction.Models.ApplicationUser", "User")
                        .WithMany("Participates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.ProjectParticipantCount", b =>
                {
                    b.HasOne("CollAction.Models.Project", "Project")
                        .WithOne("ParticipantCounts")
                        .HasForeignKey("CollAction.Models.ProjectParticipantCount", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CollAction.Models.ProjectTag", b =>
                {
                    b.HasOne("CollAction.Models.Project", "Project")
                        .WithMany("Tags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CollAction.Models.Tag", "Tag")
                        .WithMany("ProjectTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("CollAction.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CollAction.Models.ApplicationUser")
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

                    b.HasOne("CollAction.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CollAction.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
