﻿// <auto-generated />
using System;
using BookingHotel_Application.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingHotel_Application.Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240927032404_booking_db")]
    partial class booking_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("adminId");

                    b.HasIndex("userId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            adminId = 1,
                            Address = "Admin Address",
                            firstName = "Admin",
                            lastName = "User",
                            userId = "bbde3d19-c64e-44a2-ae27-058fe417c386"
                        });
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Booking", b =>
                {
                    b.Property<int>("bookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookingId"));

                    b.Property<DateTime>("bookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("bookingStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("checkIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("checkOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("bookingId");

                    b.HasIndex("roomId");

                    b.HasIndex("userId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Comment", b =>
                {
                    b.Property<int>("commentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentId"));

                    b.Property<int>("Ratings")
                        .HasColumnType("int");

                    b.Property<DateTime>("commentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("hotelId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("commentId");

                    b.HasIndex("hotelId");

                    b.HasIndex("userId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Countries", b =>
                {
                    b.Property<int>("countryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("countryId"));

                    b.Property<string>("countryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("countryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("customerId");

                    b.HasIndex("userId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Hotel", b =>
                {
                    b.Property<int>("hotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hotelId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ratings")
                        .HasColumnType("int");

                    b.Property<int?>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("hotelDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hotelId");

                    b.HasIndex("countryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Room", b =>
                {
                    b.Property<int>("roomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomId"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("guestNumber")
                        .HasColumnType("int");

                    b.Property<int?>("hotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("pricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("roomDes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomSize")
                        .HasColumnType("int");

                    b.Property<int>("roomStatus")
                        .HasColumnType("int");

                    b.Property<int?>("roomTypeId")
                        .HasColumnType("int");

                    b.HasKey("roomId");

                    b.HasIndex("hotelId");

                    b.HasIndex("roomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.RoomType", b =>
                {
                    b.Property<int>("roomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomTypeId"));

                    b.Property<string>("roomTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roomTypeId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Staff", b =>
                {
                    b.Property<int>("staffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("staffId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("staffId");

                    b.HasIndex("userId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.User", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("refreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userId = "bbde3d19-c64e-44a2-ae27-058fe417c386",
                            Email = "admin@gmail.com",
                            Role = 1,
                            Status = 1,
                            passwordHash = "$2a$11$qk0dV4lThnnjyCW71tHTJeX23C/FUPsLjepyYKd8mTk38RDXjGSjW",
                            phoneNumber = "1234567890",
                            refreshToken = "",
                            userName = "admin"
                        });
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Admin", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Booking", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingHotel_Application.Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Comment", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.Hotel", "Hotel")
                        .WithMany("Comments")
                        .HasForeignKey("hotelId");

                    b.HasOne("BookingHotel_Application.Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Customer", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Hotel", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.Countries", "Countries")
                        .WithMany("Hotels")
                        .HasForeignKey("countryId");

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Room", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("hotelId");

                    b.HasOne("BookingHotel_Application.Model.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("roomTypeId");

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Staff", b =>
                {
                    b.HasOne("BookingHotel_Application.Model.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Countries", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.Hotel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BookingHotel_Application.Model.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
