﻿// <auto-generated />
using System;
using LocationMaster_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocationMaster_API.Migrations
{
    [DbContext(typeof(LocationMasterContext))]
    [Migration("20191130140920_InitialMig")]
    partial class InitialMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LocationMaster_API.Models.Attraction", b =>
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

            modelBuilder.Entity("LocationMaster_API.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LocationMaster_API.Models.Photo", b =>
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
                });

            modelBuilder.Entity("LocationMaster_API.Models.Place", b =>
                {
                    b.Property<Guid>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

            modelBuilder.Entity("LocationMaster_API.Models.Review", b =>
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

            modelBuilder.Entity("LocationMaster_API.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                });

            modelBuilder.Entity("LocationMaster_API.Models.Attraction", b =>
                {
                    b.HasOne("LocationMaster_API.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("LocationMaster_API.Models.Place", null)
                        .WithMany("Attractions")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("LocationMaster_API.Models.Photo", b =>
                {
                    b.HasOne("LocationMaster_API.Models.Place", null)
                        .WithMany("Photos")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("LocationMaster_API.Models.Place", b =>
                {
                    b.HasOne("LocationMaster_API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("LocationMaster_API.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("LocationMaster_API.Models.Review", b =>
                {
                    b.HasOne("LocationMaster_API.Models.Place", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId");

                    b.HasOne("LocationMaster_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LocationMaster_API.Models.User", b =>
                {
                    b.HasOne("LocationMaster_API.Models.Photo", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImagePhotoId");
                });
#pragma warning restore 612, 618
        }
    }
}
