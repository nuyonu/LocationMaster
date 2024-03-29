﻿// <auto-generated />
using System;
using LocationMaster_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocationMaster_API.Migrations
{
    [DbContext(typeof(LocationMasterContext))]
    [Migration("20191228161827_addAddressSupport")]
    partial class addAddressSupport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Attraction", b =>
                {
                    b.Property<Guid>("AttractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.HasKey("AttractionId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Attractions");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Photo", b =>
                {
                    b.Property<Guid>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.HasKey("PhotoId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            PhotoId = new Guid("ffe99564-0f84-41e5-b7c8-c212d4cb4ab9"),
                            Path = "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png"
                        },
                        new
                        {
                            PhotoId = new Guid("d85f1eb4-8915-4a9d-9fff-8169b31f423a"),
                            Path = "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png"
                        },
                        new
                        {
                            PhotoId = new Guid("1b6ecbed-1081-4afe-9796-62eb943df9ef"),
                            Path = "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png"
                        });
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Place", b =>
                {
                    b.Property<Guid>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("LocationName")
                        .HasColumnType("text");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("OwnerUserId")
                        .HasColumnType("uuid");

                    b.Property<float>("TicketPrice")
                        .HasColumnType("real");

                    b.HasKey("PlaceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ReviewId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string[]>("AllowedRoles")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProfileImagePhotoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("ProfileImagePhotoId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("5f3824b1-3f62-4273-a163-298159ad632e"),
                            AllowedRoles = new[] { "admin" },
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            FirstName = "Comanel",
                            LastName = "Gigica",
                            Password = "$MYHASH$V1$10000$uT6Y0zerRx5azrQHfL+AaBLbMF3kdgJjjztzpBCUaYHqonIYxJQSWJPEihpEUX5e72SbEjTGcFZUJ2LC4f22oAun8/KbH6S/jGinh+307Lg=",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = new Guid("f6d6642e-8e2b-411a-a490-3fe4258d3743"),
                            AllowedRoles = new[] { "moderator" },
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "moderator@gmail.com",
                            FirstName = "Comanel",
                            LastName = "Jhony",
                            Password = "$MYHASH$V1$10000$r5FOAa+8/PzG3gCrPQccj3H6mcFd4LqwGox5MD5NdpKJ0Mi0TbdYVhEARJhyaZ8Ah3AXVvD7hwtl6tEwer2tAG6RI4T/IXlXUXR3mYGW1rQ=",
                            Username = "moderator"
                        },
                        new
                        {
                            UserId = new Guid("8464f6b3-b1b4-43a6-9139-0b7bd06dc0d2"),
                            AllowedRoles = new[] { "user" },
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@gmail.com",
                            FirstName = "Comanel",
                            LastName = "Florinel",
                            Password = "$MYHASH$V1$10000$KkH0ExPCpZlVjOV37w2ZZT5L8fADjyIW1frRGHVN5dyn7nHUGtL1xhNh607zV22IsNoFd1+O5Nw+I7qxcbFHIihNX90zKB5o4udYZlnbMAQ=",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Attraction", b =>
                {
                    b.HasOne("LocationMaster_API.Domain.Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("LocationMaster_API.Domain.Entities.Place", null)
                        .WithMany("Attractions")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Photo", b =>
                {
                    b.HasOne("LocationMaster_API.Domain.Entities.Place", null)
                        .WithMany("Photos")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Place", b =>
                {
                    b.HasOne("LocationMaster_API.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("LocationMaster_API.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.Review", b =>
                {
                    b.HasOne("LocationMaster_API.Domain.Entities.Place", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId");

                    b.HasOne("LocationMaster_API.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LocationMaster_API.Domain.Entities.User", b =>
                {
                    b.HasOne("LocationMaster_API.Domain.Entities.Photo", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImagePhotoId");
                });
#pragma warning restore 612, 618
        }
    }
}
